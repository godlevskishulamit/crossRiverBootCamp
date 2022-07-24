using System;
using CoronaApp.Api.Logging;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal;

public class CoronaDbContext : DbContext
{
    public CoronaDbContext(DbContextOptions options) : base(options)
    {
    }

   public DbSet<Location> Locations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<LoggingMessege> Messeges { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

