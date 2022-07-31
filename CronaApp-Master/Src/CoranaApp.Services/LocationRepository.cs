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
       
        public async Task AddNewLocation(Location location)
        {
            await locationdal.AddNewLocation(location);
        }
        public async Task EditLocation(Location location)
        {
            await locationdal.EditLocation(location);
        }
        public async Task DeleteLocation(Location location)
        {
            await locationdal.DeleteLocation(location);
        }
    }
}

 

