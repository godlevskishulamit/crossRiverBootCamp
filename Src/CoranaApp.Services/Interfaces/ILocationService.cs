using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;
public interface ILocationService
{
    Task AddLocation(Location location);
    Task DeleteLocation(Location location);
    Task<List<Location>> GetAllLocations(string city = "");
    Task<List<Location>> GetLocationsByLocationSearch(LocationSearch location);
    Task<List<Location>> GetLocationsPerPatient(string id);
}