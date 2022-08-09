using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
       // Task<ICollection<Location>> GetAllLocations(/*LocationSearch locationSearch*/);
        Task<List<LocationDTO>> GetLocationsByCity(string city);
        Task<List<LocationDTO>> GetLocationsByPatientId(string patientId);
        Task<List<LocationDTO>> GetLocationsByDate(DateTime startDate, DateTime endDate);
        Task<List<LocationDTO>> GetLocations(Models.LocationSearch locationSearch);
        Task PostLocation(LocationDTOPost location);
        Task Delete(string patientId, int locationId);


    }
}
