using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class Depart
    {
        [Key]
        public int DepartID { get; set; }
        public string DepartName { get; set; }
    }
}
