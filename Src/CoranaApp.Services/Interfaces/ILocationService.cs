namespace CoronaApp.Services.Interfaces;

public interface ILocationService
{
    Task<bool> AddLocation(AddLocationDTO location);
    Task<bool> DeleteLocation(LocationDTO location);
    Task<List<LocationDTO>> GetAllLocations();
    Task<List<LocationDTO>> GetLocationsByCity(string city);
    Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch location);
    Task<List<LocationDTO>> GetLocationsPerPatient(string id);
}