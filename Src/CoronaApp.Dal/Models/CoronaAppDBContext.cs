
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Models;
public class CoronaAppDBContext:DbContext
{
    public CoronaAppDBContext()
    {

    }
    public CoronaAppDBContext(DbContextOptions<CoronaAppDBContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer( "server=SHIRA; database=EpidemiologyReport;Trusted_Connection=True;");
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; } 
}
