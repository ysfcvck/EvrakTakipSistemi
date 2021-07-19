using ClosedXML.Excel;
using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class OutgoingDocController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        public OutgoingDocController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        Context d = new Context();

        public IActionResult Index(string barkodAra, string birimAra, string tarihAra, string personelAra)
        {
            var deger = d.OutgoingDocs.ToList();
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

        [HttpGet]
        public IActionResult Registration()
        {   //Veritabanından birim id ve birim adını viewbag e aldık.
            List<SelectListItem> deger = (from x in d.Departs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartName,
                                              Value = x.DepartID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;

            // Personel Id'yi alıyoruz..
            ViewBag.userId = _userManager.GetUserId(HttpContext.User).ToString();

            return View();
        }
        [HttpPost]
        public IActionResult Registration(OutgoingDoc g)
        {
            // Depart Id alıyoruz
            List<SelectListItem> deger = (from x in d.Departs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartName,
                                              Value = x.DepartID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;


            /* Boş geçilemez ve veri türü doğru olmalı */
            if (TryValidateModel(g, nameof(g)))
            {
                d.OutgoingDocs.Add(g);
                d.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Registration");
            }
            return View();
        }

        // Tabloyu excel e aktarma
        public IActionResult ExportExcel()
        {
            var _outgoingDoc = d.OutgoingDocs.ToList();
            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.Worksheets.Add("OutgoingDocs");
                var currentRow = 1;

                #region Header
                worksheet.Cell(currentRow, 1).Value = "ID";
                worksheet.Cell(currentRow, 2).Value = "Barkod No";
                worksheet.Cell(currentRow, 3).Value = "Belge Tarihi";
                worksheet.Cell(currentRow, 4).Value = "Belge Tipi";
                worksheet.Cell(currentRow, 6).Value = "Birim Id";
                worksheet.Cell(currentRow, 7).Value = "Personel Id";
                worksheet.Cell(currentRow, 8).Value = "Açıklama";

                #endregion

                #region Body
                foreach (var OutgoingDoc in _outgoingDoc)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = OutgoingDoc.ID;
                    worksheet.Cell(currentRow, 2).Value = OutgoingDoc.BarcodeNo;
                    worksheet.Cell(currentRow, 3).Value = OutgoingDoc.DocDate;
                    worksheet.Cell(currentRow, 4).Value = OutgoingDoc.DocType;
                    worksheet.Cell(currentRow, 6).Value = OutgoingDoc.DepartID;
                    worksheet.Cell(currentRow, 7).Value = OutgoingDoc.UserID;
                    worksheet.Cell(currentRow, 8).Value = OutgoingDoc.Descr;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "GidenEvraklar.xlsx"
                        );
                }
            }
        }
    }
}
