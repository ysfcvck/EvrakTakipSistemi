using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class IncomingDoc
    {
        [Key]
        public int ID { get;  set; }

        [Required(ErrorMessage = "Boş geçilemez !")]
        public string BarcodeNo { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen uygun formatta tarih giriniz.")]
        public DateTime DocDate { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string DocType { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string Sender { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        [StringLength(133, ErrorMessage ="Açıklama en fazla 132 karakterden oluşabilir.")]
        public string Descr { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public int DepartID { get; set; }
    }
}
