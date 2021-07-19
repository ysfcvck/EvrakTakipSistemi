using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Controllers
{
    public class AuthorityController:Controller
    {
        public IActionResult Page()
        {
            return View();
        }
    }
}
