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
            Patient patient = await context.Patients.FirstOrDefaultAsync(p=>p.Id.Equals(id));
            if(patient == null)
            {
                return null;
            }
            return await context.Locations.Where(l => l.PatientId.Equals(id)).ToListAsync();
        }
    }
    public async Task<Location> postLocation(Location loc)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
          await context.Locations.AddAsync(loc);
           await context.SaveChangesAsync();
            return loc;
        }

    }
    public async Task<List<Location>> getLocationByCity(string city)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            List<Location> listLoc = await context.Locations.Where(l => l.City.Equals(city)).ToListAsync();
            if(listLoc.Any())
            {
                return listLoc;
            }
            return null;
        }
    }
  
    public async Task<List<Location>> getByFilteredData(LocationSearch locationSearch)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Locations.Include(p => p.Patient)
                .Where(location => (location.Patient.age != null && location.Patient.age == locationSearch.Age) 
                ||(locationSearch.StartDate != null && locationSearch.EndDate != null 
                && DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 
                && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0)
                || location.Patient.age != null && location.Patient.age == locationSearch.Age 
                && locationSearch.StartDate != null && locationSearch.EndDate != null 
                && DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 
                && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0)
                .ToListAsync();

        }
    }
}
