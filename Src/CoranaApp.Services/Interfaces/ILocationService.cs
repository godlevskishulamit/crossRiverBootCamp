namespace CoronaApp.Services.Interfaces;
public interface ILocationService
{
    Task<bool> AddLocation(LocationDTO location);
    Task<bool> DeleteLocation(LocationDTO location);
    Task<List<LocationDTO>> GetAllLocations(string city = "");
    Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch location);
    Task<List<LocationDTO>> GetLocationsPerPatient(string id);
}