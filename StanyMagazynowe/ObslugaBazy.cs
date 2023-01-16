using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//używamy tego!
using Microsoft.EntityFrameworkCore;

namespace StanyMagazynowe
{
    internal class ObslugaBazy : DbContext
    {
        public DbSet<Towar> Towar { get; set; }
        public DbSet<StanMagazynowy> StanMagazynowy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = towar2.db");
            base.OnConfiguring(optionsBuilder);

        }

    }
}
