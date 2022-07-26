using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal;

public class DalLocation : IDalLocation
{
    public CoronaDbContext context;
    public DalLocation(CoronaDbContext context)
    {
        this.context = context;
    }
    public async Task<List<Location>> getAllLocations()
    {
        return await context.Locations.ToListAsync();
    }
    public async Task<List<Location>> getLocationsById(string id)
    {
        return await context.Locations.Where(l => l.PatientId == id).ToListAsync();
    }
    public void postLocation(Location loc)
    {
        context.Locations.Add(loc);
        context.SaveChanges();
    }
    public async Task<List<Location>> getLocationByCity(string city)
    {
        return await context.Locations.Where(l => l.City == city).ToListAsync();
    }
    public async Task<List<Location>> getByAge(int age)
    {
       return await context.Locations.Where(l => context.Patients.Any
        (p => p.Id == l.PatientId && p.age == age))
            .ToListAsync();
    }
    public async Task<List<Location>> getByDate(DateTime sdate, DateTime edate)
    {
        return await context.Locations.Where(l => l.StartDate <= sdate && l.EndDate >= edate).ToListAsync();
    }
}
