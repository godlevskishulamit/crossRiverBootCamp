
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
        public Task<List<Location>> getAllLocation();
        public Task<List<Location>> getLocationsByPatientId(string id);
        public Task<int> addNewLocation(Location newLocation);
        public Task<List<Location>> getAllLocationByCity(string city);
       // public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates);
        public Task<List<Location>> getFilterdLocation(LocationSearch locationSearch);


    }
}
