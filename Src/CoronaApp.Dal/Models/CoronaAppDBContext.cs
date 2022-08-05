
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Models;
public class CoronaAppDBContext:DbContext
{
    public CoronaAppDBContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-GGHPKAB; database=EpidemiologyReport;Trusted_Connection=True;");
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
}
