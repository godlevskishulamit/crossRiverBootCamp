using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Models
{
    public class CoronaContext:DbContext
    { 
        public CoronaContext() : base()
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-0OR8G5P\\ADINA; Database = CoronaApp; Trusted_Connection = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { PatientId=1, PatientName = "Tehilla" },
                new Patient() { PatientId = 2, PatientName = "Sara" },
                new Patient() { PatientId = 3, PatientName = "Aviva" }
                );

        }

    }
}
