using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Dal;

public class DalLocation : IDalLocation
{
    public IConfiguration _configuration;
    public DalLocation(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<List<Location>> getAllLocations()
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.ToListAsync();
        }
    }
    public async Task<List<Location>> getLocationsById(string id)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.Where(l => l.PatientId == id).ToListAsync();
        }
    }
    public async Task postLocation(Location loc)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
          await context.Locations.AddAsync(loc);
           await context.SaveChangesAsync();
        }

    }
    public async Task<List<Location>> getLocationByCity(string city)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.Where(l => l.City == city).ToListAsync();
        }
    }
    public async Task<List<Location>> getByAge(int age)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.Where(l => context.Patients.Any
            (p => p.Id == l.PatientId && p.age == age))
             .ToListAsync();
        }
    }
    public async Task<List<Location>> getByDate(DateTime sdate, DateTime edate)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.Where(l => l.StartDate <= sdate && l.EndDate >= edate).ToListAsync();
        }
    }
}
