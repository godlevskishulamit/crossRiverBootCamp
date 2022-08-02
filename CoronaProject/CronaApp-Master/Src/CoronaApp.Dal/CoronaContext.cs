using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal;

public class CoronaContext:DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }


    public CoronaContext(DbContextOptions options) : base(options)
    {
       
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("server=DESKTOP-8AHFHCN; database=CoronaDB;Trusted_Connection=True;");
    }


    public CoronaContext()
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasData(
            new Patient() {Id="0", Name = "John" },
            new Patient() { Id = "1", Name = "Chris" });

    }


}
