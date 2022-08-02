using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class LocationDal: ILocationDal
{
    private readonly IConfiguration _configuration;
    

    public LocationDal(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //A function that return all locations
    public async Task<List<Location>> GetAllLocations()
    {
       
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Locations.ToListAsync();
        }

    }

    //A function that return locations by city
    public async Task<List<Location>> GetLocationsByCity(string city)
    {
       
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Locations.Where(location => location.City.Equals(city)).
                       ToListAsync();
        }
    }

    //A function that return locations by date
    public async Task<List<Location>> GetLocationsByDate(LocationSearch locationSearch)
    {
     
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Locations.Where(location => DateTime.Compare(location.StartDate, locationSearch.FromDate) >= 0 &&
                                                                   DateTime.Compare(location.EndDate, locationSearch.ToDate) <= 0).ToListAsync();
        }

    }

    //A function that return locations by patient's age
    public async Task<List<Location>> GetLocationsByAge(LocationSearch locationSearch)
    {
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Locations.Include(l => l.Patient).Where(location => location.Patient.Age == locationSearch.Age).ToListAsync();
        }
    }
    //A function that add location
    public async Task PostLocation(Location location)
    {
        using (CoronaContext context = new CoronaContext())
        {
            await context.Locations.AddAsync(location);
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Failed to save changes");
            }
        }

    }

    //A function that delete location by locationId
    public async Task DeleteLocation(int locationId)
    {

        using (CoronaContext context = new CoronaContext())
        {
            var locationToDelete = await context.Locations.FindAsync(locationId);
            context.Locations.Remove(locationToDelete);
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Failed to save changes");
            }
        }

    }
}
