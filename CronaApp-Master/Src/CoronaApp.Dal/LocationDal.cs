using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class LocationDal : ILocationDal
    {
        CoronaAppContext ct;
        public LocationDal(CoronaAppContext ct)
        {
            this.ct = ct;
        }

        public async Task<List<Location>> GetByCity(string city = "")
        {
            List<Location> locations = await ct.Locations.ToListAsync();
            List<Location> result = locations.FindAll(loc => loc.City.ToLower().Contains(city.ToLower())).ToList();
           // result.Sort();
            return result;
        }
        public async Task<List<Location>> GetByPatientId(string id)
        {
            List<Location> locations = await ct.Locations.Include(l=>l.Patient).ToListAsync();
            List<Location> result = locations.Where(loc => loc.Patient.IdNumber.CompareTo(id)==0).ToList();
            //result.Sort();
            return result;
        }
        public async Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch)
        {
            List<Location> locations = await ct.Locations.ToListAsync();
            List<Location> result = locations.FindAll(loc =>
            loc.StartDate >= locationSearch.StartDate
            && loc.EndDate <= locationSearch.EndDate)
            .ToList();
            return result;
        }
        public async Task<List<Location>> GetByAge(LocationSearch locationSearch)
        {
            List<Location> locations = await ct.Locations.Include(l => l.Patient).ToListAsync();
            List<Location> result = locations.FindAll(loc =>
            loc.Patient.Age == locationSearch.Age)
            .ToList();
            return result;
        }
        public async Task Post(Location location)
        {
            await ct.Locations.AddAsync(location);
            await ct.SaveChangesAsync();
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
}
