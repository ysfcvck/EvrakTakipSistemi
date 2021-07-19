using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class Context: Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-68O6AVP\\SQLEXPRESS;Database=EvrakTakipSistemiDb;Trusted_Connection=True;");
        }

        public Microsoft.EntityFrameworkCore.DbSet<Depart> Departs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<IncomingDoc> IncomingDocs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OutgoingDoc> OutgoingDocs { get; set; }
    }
}
