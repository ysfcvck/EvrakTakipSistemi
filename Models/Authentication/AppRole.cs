using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
