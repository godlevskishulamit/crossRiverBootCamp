
using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface ILocationRepository
    {
        Task<List<Location>> getAllLocation();
        Task<int> addNewLocation(Location newLocation);
        Task<List<Location>> getLocationsByPatientId(string id);
        Task<List<Location>> getLocationsByCity(string city);
        Task<List<Location>> getLocationsByLocationSaerch(LocationSearch locationSearch);
        Task<List<Location>> getLocationsBetweenDates(LocationSearch locationSearch);
        Task<List<Location>> getLocationsByAge(LocationSearch locationSearch);


    }
}