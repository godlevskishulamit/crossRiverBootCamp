
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaAppDBContext : DbContext
    {

        IConfiguration _configurtion;
        public CoronaAppDBContext()
        {

        }
        public CoronaAppDBContext(IConfiguration IConfiguration, DbContextOptions<CoronaAppDBContext> options) : base(options)
        {
            _configurtion = IConfiguration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R5RADSP; database=EpidemiologyReport;Trusted_Connection=True;");
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
     
    }
}
