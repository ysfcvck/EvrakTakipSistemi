using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen bir rol adı girin..")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
    }
}
