using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class CoronaContext:DbContext
    {
        public CoronaContext()
        {

        }
        public CoronaContext(DbContextOptions<CoronaContext> options):base(options)
        {

        }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
