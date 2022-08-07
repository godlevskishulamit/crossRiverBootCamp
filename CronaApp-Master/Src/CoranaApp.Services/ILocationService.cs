
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
        public Task<List<Location>> getAllLocation();
        public Task<List<Location>> getLocationsByPatientId(string id);
        public Task<int> addNewLocation(PostLocationDTO newLocation);
        public Task<List<Location>> getLocationsByCity(string city);
       // public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates);
        public Task<List<Location>> getLocationsByLocationSaerch(LocationSearch locationSearch);


    }
}
