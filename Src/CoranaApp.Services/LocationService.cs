
using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CoronaApp.Dal
{
    public class LocationService: ILocationService
    {
        ILocationRepository _LocationDal;
        IMapper _mapper;
        public LocationService(ILocationRepository LocationDal, IMapper mapper)
        {
            _LocationDal =LocationDal;
            _mapper = mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public async Task<List<LocationDto>> getAllLocation()
        {
            List<Location> location = await _LocationDal.getAllLocation();
            return _mapper.Map<List<LocationDto>>(location);
        }
        public async Task<List<LocationDto>> getLocationsByPatientId(string id)
        {

            List<Location> location = await _LocationDal.getLocationsByPatientId(id);
            return _mapper.Map<List<LocationDto>>(location);
        }
        public async Task<List<LocationDto>> getAllLocationByCity( string city)
        {
            List<Location> location = await _LocationDal.getAllLocationByCity(city);
            return _mapper.Map<List<LocationDto>>(location);
        
        }
        public async Task<int> addNewLocation(LocationDto newLocation)
        {
         
            return await _LocationDal.addNewLocation(_mapper.Map<Location>(newLocation));
        }
        

        public async Task<List<LocationDto>> getFilterdLocation(LocationSearch locationSearch)
        {
            List<Location> location = await _LocationDal.getFilteredLOcation(locationSearch);
            return _mapper.Map<List<LocationDto>>(location);
        }
    }
}
