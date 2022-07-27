using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal.Models;
public class CoronaContext : DbContext
{
    public CoronaContext()
    {

    }
    IConfiguration _configurtion;
    //public CoronaContext(IConfiguration IConfiguration, DbContextOptions<CoronaContext> options) : base(options)
    //{
    //    _configurtion = IConfiguration;
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-H7OUJ7M\\SQLEXPRESS;Database=Corona;Trusted_Connection=True;");
        //optionsBuilder.UseSqlServer(_configurtion.GetSection("ConnectionStrings")["CoronaConnection"]);
    }
    public virtual DbSet<Patient> Patient { get; set; }
    public virtual DbSet<Location> Location { get; set; }
    public virtual DbSet<User> User { get; set; }
}