using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Models;

public class CoronaContext : DbContext
{
    private readonly IConfiguration _configuration;
    public CoronaContext(IConfiguration config)
    {
        _configuration = config;
    }

    public CoronaContext(DbContextOptions<CoronaContext> options, IConfiguration config):base(options)
    {
        _configuration = config;

    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:myDatabase"]);
    }
}
