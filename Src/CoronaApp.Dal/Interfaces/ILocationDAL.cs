namespace CoronaApp.Dal.Interfaces;

public interface ILocationDAL
{
    Task<List<Location>> GetAllLocations();
    Task<List<Location>> GetLocationsByCity(string city);
    Task<List<Location>> GetLocationByAge(LocationSearch location);
    Task<List<Location>> GetLocationsByDate(LocationSearch location);
    Task<List<Location>> GetLocationsByPatient(string id);
    Task<bool> AddLocation(Location location);
    Task<bool> DeleteLocation(Location location);
}