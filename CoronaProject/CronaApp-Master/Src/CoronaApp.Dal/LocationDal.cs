using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class LocationDal: ILocationDal
{
    private readonly CoronaContext _context;

    public LocationDal(CoronaContext context)
    {
        _context = context;
    }

    //A function that return all locations
    public async Task<List<Location>> GetAllLocations()
    {
        return  await _context.Locations.ToListAsync();
       
    }

    //A function that return locations by city
    public async Task<List<Location>> GetLocationsByCity(string city)
    {
        return await _context.Locations.Where(location => location.City.Equals(city)).
            ToListAsync();
    }

    //A function that return locations by date
    public async Task<List<Location>> GetLocationsByDate(LocationSearch locationSearch)
    {
        return await _context.Locations.Where(location => DateTime.Compare(location.StartDate, locationSearch.FromDate) >=0 &&
                                                          DateTime.Compare(location.EndDate, locationSearch.ToDate)<=0).ToListAsync();     
    }

    //A function that return locations by patient's age
    public async Task<List<Location>> GetLocationsByAge(LocationSearch locationSearch)
    {
        return await _context.Locations.Include(l=>l.Patient).Where(location => location.Patient.Age==locationSearch.Age).ToListAsync();
    }
}
