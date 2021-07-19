using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class Contact
    {
        [Required(ErrorMessage = "Boş geçilemez !")]
        public string baslik { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string icerik { get; set; }


        [Required(ErrorMessage = "Boş geçilemez !")]
        public string AdSoyad { get; set; }


        [Required,EmailAddress(ErrorMessage = "Lütfen ornek@ formatında bir mail giriniz.")]
        public string eposta { get; set; }
    }
}
