
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
        public Task<List<LocationDto>> getAllLocation();
        public Task<List<LocationDto>> getLocationsByPatientId(string id);
        public Task<int> addNewLocation(LocationDto newLocation);
        public Task<List<LocationDto>> getAllLocationByCity(string city);
       
        public Task<List<LocationDto>> getFilterdLocation(LocationSearch locationSearch);


    }
}
