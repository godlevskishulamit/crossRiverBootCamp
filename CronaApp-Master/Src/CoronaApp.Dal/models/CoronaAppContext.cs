using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace CoronaApp.Dal.models;

public class CoronaAppContext : DbContext
{
    IConfiguration _configuration;
    public CoronaAppContext()
    {

    }
    public CoronaAppContext(IConfiguration config, DbContextOptions<CoronaAppContext> options) : base(options)
    {
        this._configuration = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("conLeah"));
    }




    public DbSet<Location> Locations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
}

