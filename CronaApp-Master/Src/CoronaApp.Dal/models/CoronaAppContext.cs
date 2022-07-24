using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace CoronaApp.Dal.models
{
   public class CoronaAppContext:DbContext 
    {
        public CoronaAppContext(DbContextOptions<CoronaAppContext> options) : base(options)
        {

        }
        public CoronaAppContext()
        {

        }
      
        public DbSet<Location> Locations { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
