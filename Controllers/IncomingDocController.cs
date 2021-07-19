using ClosedXML.Excel;
using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.Context;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace EvrakTakipSistemi.Controllers
{
    [Authorize(Roles = "Admin,Moderator,User")]
    public class IncomingDocController:Controller
    {
        readonly UserManager<AppUser> _userManager;
        Context c = new Context();



        public IncomingDocController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // Evrak liste ve filtre
        public IActionResult Index(string barkodAra, string birimAra, string tarihAra, string personelAra)
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

        // Evrak kayıt

        [HttpGet]
        public IActionResult Registration()
        {
            // Personel Id'yi alıyoruz..
            ViewBag.userId = _userManager.GetUserId(HttpContext.User).ToString();

            //Veritabanından birim id ve birim adını viewbag e alıyoruz.
            List<SelectListItem> degerler = (from x in c.Departs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartName,
                                                 Value = x.DepartID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public IActionResult Registration(IncomingDoc g)
        {
            //Deparman listesi
            List<SelectListItem> degerler = (from x in c.Departs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartName,
                                                 Value = x.DepartID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            /* Veri türü kontrolü */
            if (TryValidateModel(g, nameof(g)))
            {
                c.IncomingDocs.Add(g);
                c.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Registration");
            }
            else
                return View();
        }

        // Tabloyu excel e aktarma
        public IActionResult ExportExcel()
        {
            var _incomingDoc = c.IncomingDocs.ToList();
            using (var workbook=new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("IncomingDocs");
                var currentRow = 1;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "ID";
                worksheet.Cell(currentRow, 2).Value = "Barkod No";
                worksheet.Cell(currentRow, 3).Value = "Belge Tarihi";
                worksheet.Cell(currentRow, 4).Value = "Belge Tipi";
                worksheet.Cell(currentRow, 5).Value = "Gönderen";
                worksheet.Cell(currentRow, 6).Value = "Birim Id";
                worksheet.Cell(currentRow, 7).Value = "Personel Id";
                worksheet.Cell(currentRow, 8).Value = "Açıklama";

                #endregion

                #region Body
                foreach (var IncomingDoc in _incomingDoc)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = IncomingDoc.ID;
                    worksheet.Cell(currentRow, 2).Value = IncomingDoc.BarcodeNo;
                    worksheet.Cell(currentRow, 3).Value = IncomingDoc.DocDate;
                    worksheet.Cell(currentRow, 4).Value = IncomingDoc.DocType;
                    worksheet.Cell(currentRow, 5).Value = IncomingDoc.Sender;
                    worksheet.Cell(currentRow, 6).Value = IncomingDoc.DepartID;
                    worksheet.Cell(currentRow, 7).Value = IncomingDoc.UserID;
                    worksheet.Cell(currentRow, 8).Value = IncomingDoc.Descr;
                }
                #endregion

                using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "GelenEvraklar.xlsx"
                        );
                }
            }
        }
    }
}
