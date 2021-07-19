using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class OutgoingDoc
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş geçilemez !")]
        public string BarcodeNo { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen uygun formatta tarih giriniz.")]
        public DateTime DocDate { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string DocType { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string Descr { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public int DepartID { get; set; }
    }
}
