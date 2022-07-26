
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaAppDBContext : DbContext
    {
        public CoronaAppDBContext(DbContextOptions<CoronaAppDBContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new User() { Id = 0, Name = "cy88858@gmail.com", Password = "21354808" });

        }*/
    }
}
