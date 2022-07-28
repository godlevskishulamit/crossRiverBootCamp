using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Models;
public class CoronaAppContext : DbContext
{
    public CoronaAppContext(DbContextOptions<CoronaAppContext> options) : base(options)
    {
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
}