using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-A8BTK9B\SQL2019;Database=CoronaDB2;Trusted_Connection=True;");
        }
    }
}
