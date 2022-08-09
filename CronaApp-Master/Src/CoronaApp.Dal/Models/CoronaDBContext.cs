using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Models;

    public class CoronaDBContext : DbContext

    {

        public CoronaDBContext()
        {

        }
        public CoronaDBContext(DbContextOptions<CoronaDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;database=CoronaDB;Trusted_Connection=True;");
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
    }

