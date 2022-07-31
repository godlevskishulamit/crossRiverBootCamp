using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Models
{
    public class CoronaContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public CoronaContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _configuration = config;
        }
        public CoronaContext(IConfiguration config)
        {
            _configuration=config;
        }
        public DbSet<LocationDto> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:myDatabase"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { PatientId = "1", PatientName = "Tehilla" },
                new Patient() { PatientId = "2", PatientName = "Sara" },
                new Patient() { PatientId = "3", PatientName = "Aviva" }
                );

        }

    }
}
