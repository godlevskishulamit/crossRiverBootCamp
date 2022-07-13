using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaDBContext:DbContext

    {
       
        public CoronaDBContext(DbContextOptions<CoronaDBContext> options):base(options)
        {
            
        }
       public DbSet<Location> Locations { get; set; }
       public DbSet<Patient> Patients { get; set; }
    }
}
