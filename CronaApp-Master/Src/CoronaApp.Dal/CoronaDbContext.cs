using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal;

public class CoronaDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public CoronaDbContext(IConfiguration configuration) 
    {
        _configuration = configuration;
    }

   public DbSet<Location> Locations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(_configuration.GetConnectionString("myconn"));
    }
}

