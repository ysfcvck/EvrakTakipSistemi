using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace EvrakTakipSistemi.Controllers
{
    [Authorize(Roles = "Admin,Moderator,User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Warning()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact model) //İletişim
        {
            if (ModelState.IsValid)
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("destek@evraktakip.online", "Evrak Takip Sistemi", System.Text.Encoding.UTF8);
                msg.To.Add("destek@evraktakip.online");
                msg.Subject = model.baslik;
                msg.Body = "Personel: " + model.AdSoyad + "<br><br>" + model.icerik + "<br><br> Eposta: " + model.eposta;
                msg.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("destek@evraktakip.online", "@Ysf.98783+");
                    client.Host = "plsk21.servername.co";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    try
                    {
                        client.Send(msg);
                        TempData["Message"] = "Mesajınız iletilmiştir. En kısa sürede incelenecektir.";

                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Mesaj gönderilemedi. Hata nedeni:" + ex.Message;
                    }
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}
