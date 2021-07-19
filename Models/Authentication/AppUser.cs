using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.Authentication
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string Adress { get; set; }
    }
}
