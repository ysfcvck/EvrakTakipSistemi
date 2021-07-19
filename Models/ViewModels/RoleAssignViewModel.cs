using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasAssign { get; set; }
    }
}
