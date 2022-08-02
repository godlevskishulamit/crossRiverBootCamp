using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILocationDal _locationDal;
        private readonly IMapper _mapper;

        public LocationRepository(ILocationDal locationDal)
        {
            _locationDal = locationDal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }
        //A function that return all locations
        public async Task<List<LocationDTO>> GetAllLocations()
        {
            var locations = await _locationDal.GetAllLocations();
            return _mapper.Map<List<Location>, List<LocationDTO>>(locations);

        }

        //A function that return locations by city
        public async Task<List<LocationDTO>> GetLocationsByCity(string city)
        {
            var locations = await _locationDal.GetLocationsByCity(city);
            return _mapper.Map<List<Location>, List<LocationDTO>>(locations);
        } 

        //A function that return locations by date
        public async Task<List<LocationDTO>> GetLocationsByDate(LocationSearch locationSearch)
        {
            var locations = await _locationDal.GetLocationsByDate(locationSearch);
            return _mapper.Map<List<Location>, List<LocationDTO>>(locations);
        }

        //A function that return locations by patient's age
        public async Task<List<LocationDTO>> GetLocationsByAge(LocationSearch locationSearch)
        {
            var locations = await _locationDal.GetLocationsByAge(locationSearch);
            return _mapper.Map<List<Location>, List<LocationDTO>>(locations);
        }

        //A function that add location
        public async Task PostLocation(LocationDTO location)
        {
            Location locationFromDTO = _mapper.Map<LocationDTO, Location>(location);
            await _locationDal.PostLocation(locationFromDTO);
        }

        //A function that delete location by locationId
        public async Task DeleteLocation(int locationId)
        {
            await _locationDal.DeleteLocation(locationId);
        }
    }
}
