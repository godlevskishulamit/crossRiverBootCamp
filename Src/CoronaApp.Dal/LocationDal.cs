using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public class LocationDal : ILocationDal
{
    CoronaAppContext _CoronaAppDBContext;
    public LocationDal(CoronaAppContext CoronaAppDBContext)
    {
        _CoronaAppDBContext = CoronaAppDBContext;
    }

    public async Task<List<Location>> getAllLocation()
    {
        return await _CoronaAppDBContext.Locations.ToListAsync();
    }

    public async Task<List<Location>> getLocationsByPatientId(string id)
    {
        if (id == null)
        {
            throw new ArgumentNullException("id");
        }
        else
        {
            return await _CoronaAppDBContext.Locations.Where(location => location.Patient.Id.CompareTo(id) == 0).ToListAsync();
        }

    }

    public async Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates)
    {
        if (dates == null)
        {
            throw new ArgumentNullException("dates");
        }
        else
        {
            return await _CoronaAppDBContext.Locations.Where(location => DateTime.Compare(dates.StartDate, location.StartDate) <= 0 && DateTime.Compare(dates.EndDate, location.EndDate) >= 0).ToListAsync();
        }

    }

    public async Task<List<Location>> getAllLocationByCity(string city)
    {
        if (city == null)
        {
            throw new ArgumentNullException("city");
        }
        else
        {
            return await _CoronaAppDBContext.Locations.Where(location => location.City.Contains(city)).ToListAsync();
        }
    }

    public async Task<List<Location>> getAllLocationByAge(LocationSearch age)
    {
        if (age == null)
        {
            throw new ArgumentNullException("age");
        }
        else
        {
            return await _CoronaAppDBContext.Locations.Include(location => location.Patient)
                .Where(location => location.Patient.Age == age.Age).ToListAsync();
        }
    }

    public async Task<int> addNewLocation(Location newLocation)
    {
        if (newLocation == null)
        {
            throw new ArgumentNullException("newLocation");
        }
        else
        {
            await _CoronaAppDBContext.Locations.AddAsync(newLocation);
            await _CoronaAppDBContext.SaveChangesAsync();
            return newLocation.Id;
        }
    }
}
