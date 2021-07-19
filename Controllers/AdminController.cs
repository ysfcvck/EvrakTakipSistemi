using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        Context c = new Context();
        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        ////-------------------- GİRİŞ İŞLEMİ --------------------//
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
                     

                        return RedirectToAction("Index", "Admin");
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
                                ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }
            }
            //return View(model);
            return RedirectToAction("Index", "Admin");
        }
        
        // ANASAYFA
        public IActionResult Index()
        {
            return View();
        }

        //-------------------- EVRAK İŞLEMLERİ --------------------//

        // GELEN EVRAK LİSTELEME VE FİLTRE
       
        public IActionResult IncomingDoc(string barkodAra, string birimAra, string tarihAra, string personelAra)
        {
            var degerler = c.IncomingDocs.ToList();
            if (!string.IsNullOrEmpty(barkodAra))
            {
                degerler = degerler.Where(x => x.BarcodeNo.Contains(barkodAra)).ToList();
            }
            if (!string.IsNullOrEmpty(birimAra))
            {
                degerler = degerler.Where(x => x.DepartID.ToString().Contains(birimAra)).ToList();
            }
            if (!string.IsNullOrEmpty(personelAra))
            {
                degerler = degerler.Where(x => x.UserID.ToString().Contains(personelAra)).ToList();
            }
            if (!string.IsNullOrEmpty(tarihAra))
            {
                degerler = degerler.Where(x => x.DocDate.ToString().Contains(tarihAra)).ToList();
            }
            return View(degerler);
        }

        // GELEN EVRAK SİLME
        public IActionResult DeleteIncomingDoc(int Id)
        {
            var IncomingDoc = c.IncomingDocs.Find(Id);
            c.IncomingDocs.Remove(IncomingDoc);
            c.SaveChanges();
            return RedirectToAction("IncomingDoc");
        }

        // GİDEN EVRAK LİSTE VE FİLTRE
        public IActionResult OutgoingDoc(string barkodAra, string birimAra, string tarihAra, string personelAra)
        {
            var deger = c.OutgoingDocs.ToList();
            if (!string.IsNullOrEmpty(barkodAra))
            {
                deger = deger.Where(x => x.BarcodeNo.Contains(barkodAra)).ToList();
            }
            if (!string.IsNullOrEmpty(birimAra))
            {
                deger = deger.Where(x => x.DepartID.ToString().Contains(birimAra)).ToList();
            }
            if (!string.IsNullOrEmpty(personelAra))
            {
                deger = deger.Where(x => x.UserID.ToString().Contains(personelAra)).ToList();
            }
            if (!string.IsNullOrEmpty(tarihAra))
            {
                deger = deger.Where(x => x.DocDate.ToString().Contains(tarihAra)).ToList();
            }
            return View(deger);
        }
        // GİDEN EVRAK SİLME
        public IActionResult DeleteOutgoingDoc(int Id)
        {
            var OutgoingDoc = c.OutgoingDocs.Find(Id);
            c.OutgoingDocs.Remove(OutgoingDoc);
            c.SaveChanges();
            return RedirectToAction("OutgoingDoc");
        }

        // GELEN EVRAK GETİRME
        public IActionResult IncomingDocGet(int id)
        {
            // Personel Id'yi alıyoruz..
            var userid = _userManager.GetUserId(HttpContext.User);
            ViewBag.userId = userid;

            var IncomingDoc = c.IncomingDocs.Find(id);
            return View("IncomingDocGet", IncomingDoc);
        }

        // GELEN EVRAK GÜNCELLEME
        public IActionResult UpdateIncomingDoc(IncomingDoc d)
        {
            var IncomingDoc = c.IncomingDocs.Find(d.ID);
            if (TryValidateModel(d, nameof(d)))
            { 
                IncomingDoc.BarcodeNo = d.BarcodeNo;
                IncomingDoc.DocDate =d.DocDate;
                IncomingDoc.Sender = d.Sender;
                IncomingDoc.DocType = d.DocType;
                IncomingDoc.Descr = d.Descr;
                IncomingDoc.DepartID = d.DepartID;
                IncomingDoc.UserID = d.UserID;

                c.SaveChanges();
                return RedirectToAction("IncomingDoc");
            }
            return View("IncomingDocGet", IncomingDoc);
        }

        // GİDEN EVRAK GETİRME
        public IActionResult OutgoingDocGet(int id)
        {
            // Personel Id'yi alıyoruz..
            var userid = _userManager.GetUserId(HttpContext.User);
            ViewBag.userId = userid;

            var OutgoingDoc = c.OutgoingDocs.Find(id);
            return View("OutgoingDocGet", OutgoingDoc);
        }

        // Giden EVRAK GÜNCELLEME
        public IActionResult UpdateOutgoingDoc(OutgoingDoc d)
        {
            var OutgoingDoc = c.OutgoingDocs.Find(d.ID);

            if (TryValidateModel(d, nameof(d)))
            {
                OutgoingDoc.BarcodeNo = d.BarcodeNo;
                OutgoingDoc.DocDate = d.DocDate;
                OutgoingDoc.DocType = d.DocType;
                OutgoingDoc.Descr = d.Descr;
                OutgoingDoc.DepartID = d.DepartID;
                OutgoingDoc.UserID = d.UserID;

                c.SaveChanges();
                return RedirectToAction("OutgoingDoc");
            }
            return View("OutgoingDocGet", OutgoingDoc);
        }
    }
}
