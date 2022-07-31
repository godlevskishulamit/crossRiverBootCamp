using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Dto;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        ILocationDal _dal;
        IMapper _mapper;
        
        public LocationRepository(ILocationDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public Task<List<Location>> getAllLocations()
        {
          return _dal.getAllLocationsAsync();
        }

        public Task<List<Location>> getByAge(int age)
        {
            return _dal.getByAgeAsync(age);
        }

        public Task<List<Location>> getByCity(string city)
        {
            return _dal.getByCityAsync(city);
        }

        public Task<List<Location>> getByDate(DateTime startDate, DateTime endDate)
        {
            return _dal.getByDateAsync(startDate, endDate);
        }

        public Task<List<Location>> getByUserId(string id)
        {
            return _dal.getByUserIdAsync(id);
        }

        public void postExposure(string id, LocationPostDto location)
        {
            Location newLocation= _mapper.Map<Location>(location);
             
            _dal.postExposure(id, newLocation);
        }
    }
}
