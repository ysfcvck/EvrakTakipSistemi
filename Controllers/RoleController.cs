using EvrakTakipSistemi.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvrakTakipSistemi.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class RoleController : Controller
    {
        Context c = new Context();
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // ROL ATAMA-YETKİ VERME
        public async Task<IActionResult> RoleAssign(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);            

            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }

            //Yetkilendirme işleminden sonra kullanıcıya mail gönderme
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("destek@evraktakip.online", "Evrak Takip Sistemi", System.Text.Encoding.UTF8);
            msg.To.Add(user.Email);
            msg.Subject = "Bilgilendirme";
            msg.Body = "Sayın " + user.NameSurname + ",<br><br>" + " Gerekli erişim izinleri hesabınıza tanımlanmıştır. Eposta adresiniz ve şifreniz ile https://evraktakip.online bağlantısından sisteme giriş yapabilirsiniz." + "<br>" + "İyi çalışmalar dileriz..";
            msg.IsBodyHtml = true;

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("destek@evraktakip.online", "@Ysf.98783+");
                client.Host = "plsk21.servername.co";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }

            return RedirectToAction("index", "user");
        }

        // ROL LİSTELEME
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        //ROL SİLME
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            
            if (role.Name=="Admin")// Admin rolü silinemez
            {
                TempData["ErrorMsg"] = "Admin rolü silinemez !";

                return RedirectToAction("index");
            }
            else
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    //Başarılı...
                }
                return RedirectToAction("index");
            }
        }

        // ROL EKLEME
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string id)
        {
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);

                return View(new RoleViewModel
                {
                    Name = role.Name
                });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
                result = await _roleManager.CreateAsync(new AppRole { Name = model.Name, OlusturulmaTarihi = DateTime.Now });

            if (result.Succeeded)
            {
                //Başarılı...
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
    }
}
