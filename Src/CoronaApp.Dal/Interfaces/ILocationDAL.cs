using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Interfaces;

public interface ILocationDAL
{
    Task<List<Location>> GetAllLocations(string city = "");
    Task<List<Location>> GetLocationByAge(LocationSearch location);
    Task<List<Location>> GetLocationsByDate(LocationSearch location);
    Task<List<Location>> GetLocationsPerPatient(string id);
    Task<bool> AddLocation(Location location);
    Task<bool> DeleteLocation(Location location);
}