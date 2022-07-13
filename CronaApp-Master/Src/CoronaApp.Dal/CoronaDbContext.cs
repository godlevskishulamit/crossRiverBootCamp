using System;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal
{
    public class CoronaDbContext : DbContext
    {
        public CoronaDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
    new Patient() { Id = "212825376", name = "Shani" },
    new Patient() { Id = "324103357", name = "Miriam" });

        }
    }

}
