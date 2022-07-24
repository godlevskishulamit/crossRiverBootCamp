using CoronaApp.Dal;
using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        ILocationDal locationdal;
        public LocationRepository(ILocationDal locationdal)
        {
            this.locationdal = locationdal;
        }

        public async Task<List<Location>> GetByCity(string city)
        {
            return await locationdal.GetByCity(city);
        }
        public async Task<List<Location>> GetByPatientId(string id)
        {

            return await locationdal.GetByPatientId(id);
        }
        public async Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch)
        {
            if (locationSearch.Age != 0)
               return await locationdal.GetByAge(locationSearch);
            return await locationdal.GetByLocationSearch(locationSearch);
        }
       
        public async Task Post(Location location)
        {
            await locationdal.Post(location);
        }
        public async Task Put(Location location)
        {
            await locationdal.Put(location);
        }
        public async Task Delete(Location location)
        {
            await locationdal.Delete(location);
        }
    }
}

 

