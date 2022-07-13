using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
       // Task<ICollection<Location>> GetAllLocations(/*LocationSearch locationSearch*/);
        Task<List<Location>> GetLocationsByCity(string city);
        Task<List<Location>> GetLocationsByPatientId(string patientId);
        Task<List<Location>> GetLocationsByDate(DateTime startDate, DateTime endDate);
        Task<List<Location>> GetLocations(Models.LocationSearch locationSearch);
        Task PostLocation(Location location);
        Task Delete(string patientId, int locationId);


    }
}
