using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class LocationDal : ILocationDal
{
    CoronaAppContext ct;
    public LocationDal(CoronaAppContext ct)
    {
        this.ct = ct;
    }

    public async Task<List<Location>> GetByCity(string city = "")
    {
        List<Location> locations = await ct.Locations
        .Where(loc => loc.City.ToLower().Contains(city)).ToListAsync();
        if (locations.Count == 0)
            return null;
        return locations;
    }
    public async Task<List<Location>> GetByPatientId(string id)
    {
        List<Location> locations = await ct.Locations
        .Where(loc => loc.Patient.IdNumber.CompareTo(id) == 0).ToListAsync();
        if (locations.Count == 0)
            return null;
        return locations;
    }
    public async Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch)
    {
        List<Location> locations = await ct.Locations
        .Where(loc => loc.StartDate >= locationSearch.StartDate
        && loc.EndDate <= locationSearch.EndDate)
        .ToListAsync();
        if (locations.Count == 0)
            return null;
        return locations;
    }
    public async Task<List<Location>> GetByAge(LocationSearch locationSearch)
    {

        List<Location> locations = await ct.Locations.Where(loc =>
        loc.Patient.Age == locationSearch.Age).ToListAsync();
        if (locations.Count == 0)
            return null;
        return locations;
    }
    public async Task Post(Location location)
    {
        try
        {
            await ct.Locations.AddAsync(location);
            await ct.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("failed to save changes in data base");
        }
    }
    public async Task Put(Location location)
    {
        Location locationToUpdate = await ct.Locations.Where(l => l.Id == location.Id).FirstOrDefaultAsync();
        if (locationToUpdate == null)
            return;
        ct.Entry(locationToUpdate).CurrentValues.SetValues(location);
        await ct.SaveChangesAsync();
    }
    public async Task Delete(Location location)
    {
        ct.Locations.Remove(location);
        await ct.SaveChangesAsync();
    }
}

