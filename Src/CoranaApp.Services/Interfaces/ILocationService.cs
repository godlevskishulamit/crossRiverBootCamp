using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;

public interface ILocationService
{
    Task<bool> AddLocation(AddLocationDTO location);
    Task<bool> DeleteLocation(LocationDTO location);
    Task<List<LocationDTO>> GetAllLocations(string city = "");
    Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch location);
    Task<List<LocationDTO>> GetLocationsPerPatient(string id);
}