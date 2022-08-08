using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.models;
using CoronaApp.Services.DTO;
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
        IMapper mapper;
        public LocationRepository(ILocationDal locationdal ,IMapper mapper)
        {
            this.locationdal = locationdal;
            this.mapper = mapper;
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
            List<Location> allLocations = new List<Location>();
            if (locationSearch.Age != 0)
                allLocations.AddRange(await locationdal.GetByAge(locationSearch));
            if (locationSearch.StartDate != null || locationSearch.EndDate != null)
                allLocations.AddRange(await locationdal.GetByLocationSearch(locationSearch));
            return allLocations;
        }
       
        public async Task AddNewLocation(LocationPostDTO location)
        {
            Location newlocation = mapper.Map<Location>(location);
            await locationdal.AddNewLocation(newlocation);
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

 

