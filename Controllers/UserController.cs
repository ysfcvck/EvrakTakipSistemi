using ClosedXML.Excel;
using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace EvrakTakipSistemi.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class UserController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //GİRİŞ İŞLEMİ
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, model.Lock);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user); //Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.

                        return RedirectToAction("warning", "home");
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user); //Eğer ki başarısız bir account girişi söz konusu ise AccessFailedCount kolonundaki değer +1 arttırılacaktır. 

                        int failcount = await _userManager.GetAccessFailedCountAsync(user); //Kullanıcının yapmış olduğu başarısız giriş deneme adedini alıyoruz.
                        if (failcount == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1))); //Eğer ki başarısız giriş denemesi 3'ü bulduysa ilgili kullanıcının hesabını kilitliyoruz.
                            ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
                        }
                        else
                        {
                            if (result.IsLockedOut)
                                ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kilitlenmiştir.");
                            else
                                ModelState.AddModelError("NotUser2", "Hatalı şifre! Lütfen şifrenizi kontrol edin.");
                        }

                        TempData["ErrorMsg"] = "";
                        foreach (var items in ModelState.Values)
                        {
                            foreach (var er in items.Errors)
                            {

                                TempData["ErrorMsg"] = er.ErrorMessage.ToString() + TempData["ErrorMsg"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamakta.");
                    TempData["ErrorMsg"] = "";
                    foreach (var items in ModelState.Values)
                    {
                        foreach (var er in items.Errors)
                        {

                            TempData["ErrorMsg"] = er.ErrorMessage.ToString() + TempData["ErrorMsg"].ToString();
                        }
                    }
                }
            }

            return View(model);
        }

        //ÇIKIŞ İŞLEMİ
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        //Kullanıcı Listeleme ve Arama
        public IActionResult Index(string id, string userName, string email, string NameSurname)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View(_userManager.Users.Where(x => x.Id.ToString().Contains(id) || id == null));
            }
            if (!string.IsNullOrEmpty(userName))
            {
                return View(_userManager.Users.Where(x => x.UserName.Contains(userName) || userName == null));
            }
            if (!string.IsNullOrEmpty(email))
            {
                return View(_userManager.Users.Where(x => x.Email.Contains(email) || email == null));
            }
            if (!string.IsNullOrEmpty(NameSurname))
            {
                return View(_userManager.Users.Where(x => x.NameSurname.Contains(NameSurname) || NameSurname == null));
            }
            return View(_userManager.Users);
        }

        // KAYIT İŞLEMİ
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = appUserViewModel.UserName,
                    Email = appUserViewModel.Email,
                    NameSurname = appUserViewModel.NameSurname,
                    PhoneNumber = appUserViewModel.PhoneNumber,
                    Adress = appUserViewModel.Adress,

                };
                IdentityResult result = await _userManager.CreateAsync(appUser, appUserViewModel.Sifre);
                if (result.Succeeded)
                {
                    ModelState.Clear();

                    // Kayıt tamamlandıktan sonra sistem epostasına bilgilendirici mail gönderme
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("destek@evraktakip.online", "Evrak Takip Sistemi", System.Text.Encoding.UTF8);
                    msg.To.Add("destek@evraktakip.online");
                    msg.Subject = "Yeni Kayıt";
                    msg.Body = "Kullanıcı Adı: " + appUser.UserName + "<br><br>" + "Eposta: " + appUser.Email + "<br><br> Lütfen gerekli incelemeleri yaptıktan sonra uygun yetkileri veriniz..";
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
                    ViewBag.State = true;
                }
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));

            }
            return View();
        }

        // PERSONEL BİLGİ GETİRME
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new AppUserViewModel
            {
                UserName = user.UserName,
                NameSurname = user.NameSurname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Adress = user.Adress,
            };
            return View(model);
        }

        // PERSONEL BİLGİ GÜNCELLEME
        [HttpPost]
        public async Task<IActionResult> EditUser(AppUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());

            user.UserName = model.UserName;
            user.NameSurname = model.NameSurname;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Adress = model.Adress;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        //PERSONEL KAYIT SİLME
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>; //Seçilen personelin rollerini listeliyoruz.

            if (userRoles.Contains("Admin")) //Eger userRoles listesinde Admin değeri varsa.
            {
                TempData["ErrorMsg"] = "Admin yetkisi olan kullanıcı silinemez !";

                return RedirectToAction("index");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    //Başarılı..
                }
                return RedirectToAction("index");
            }

        }

        // Personel tablosunu excel e aktarma
        public IActionResult ExportExcel()
        {
            var _users = _userManager.Users.ToList();
            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "Personel Id";
                worksheet.Cell(currentRow, 2).Value = "Kullanıcı Adı";
                worksheet.Cell(currentRow, 3).Value = "Ad Soyad";
                worksheet.Cell(currentRow, 4).Value = "Adres";
                worksheet.Cell(currentRow, 5).Value = "Eposta";
                worksheet.Cell(currentRow, 6).Value = "Telefon";
                #endregion

                #region Body
                foreach (var users in _users)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = users.Id;
                    worksheet.Cell(currentRow, 2).Value = users.UserName;
                    worksheet.Cell(currentRow, 3).Value = users.NameSurname;
                    worksheet.Cell(currentRow, 4).Value = users.Adress;
                    worksheet.Cell(currentRow, 5).Value = users.Email;
                    worksheet.Cell(currentRow, 6).Value = users.PhoneNumber;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Personeller.xlsx"
                        );
                }
            }
        }

        // Şifre yenileme linki gönderme
        [AllowAnonymous]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPasswordViewModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress("destek@evraktakip.online", "Evrak Takip Sistemi", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://evraktakip.online{Url.Action("UpdatePassword", "User", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential("destek@evraktakip.online", "@Ysf.98783+");
                smp.Port = 587;
                smp.Host = "plsk21.servername.co";
                smp.EnableSsl = true;
                smp.Send(mail);

                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
        }

        // Şifre güncelleme
        [AllowAnonymous]
        [HttpGet("[action]/{userId}/{token}")]
        public IActionResult UpdatePassword(string userId, string token)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("[action]/{userId}/{token}")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model, string userId, string token)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), model.Password);
            if (result.Succeeded)
            {
                ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
            }
            else
                ViewBag.State = false;
            return View();
        }

        [AllowAnonymous]
        public IActionResult UserAgreement()
        {
            return View();
        }
    }
}