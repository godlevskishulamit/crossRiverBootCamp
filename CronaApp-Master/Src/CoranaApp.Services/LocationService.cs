
using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CoronaApp.Dal
{
    public class LocationService : ILocationService
    {
        ILocationRepository _LocationDal;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository LocationDal, IMapper mapper)
        {
            _LocationDal = LocationDal;
            _mapper = mapper;
        }
        public async Task<List<Location>> getAllLocation()
        {
            return await _LocationDal.getAllLocation();
        }
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
            return await _LocationDal.getLocationsByPatientId(id);
        }
        public async Task<List<Location>> getLocationsByCity(string city)
        {
            return await _LocationDal.getLocationsByCity(city);
        }
        public async Task<int> addNewLocation(PostLocationDTO newLocation)
        {
            Location location = _mapper.Map<Location>(newLocation);
            return await _LocationDal.addNewLocation(location);
        }


        public async Task<List<Location>> getLocationsByLocationSaerch(LocationSearch locationSearch)
        {
            if(locationSearch.Age!=0 && locationSearch.StartDate != null && locationSearch.EndDate != null)
            {
                return await _LocationDal.getLocationsByLocationSaerch(locationSearch);
            }
            if (locationSearch.Age != 0)
            {
                return await _LocationDal.getLocationsByAge(locationSearch);
            }
            if (locationSearch.StartDate != null && locationSearch.EndDate != null)
            {
                return await _LocationDal.getLocationsBetweenDates(locationSearch);
            }
            return null;
        }
    }
}
