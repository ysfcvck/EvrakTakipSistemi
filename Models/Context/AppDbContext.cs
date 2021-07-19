using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext) { }
        
    }
}




