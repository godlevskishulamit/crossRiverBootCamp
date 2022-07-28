
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Models;
public class CoronaAppDBContext:DbContext
{
    public CoronaAppDBContext()
    {
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
}
