namespace CoronaApp.Dal.Classes;
public class LocationDalMock : ILocationDAL
{
    public LocationDalMock()
    {
    }

    List<Location> list = new List<Location>()
        {
            new Location(0,DateTime.Now,DateTime.Now,"Jerusalem","Here","123456789"){ },
            new Location(1,DateTime.Now,DateTime.Now,"Bnei-brak","Here","987654321"){ }
        };

    public Task<bool> AddLocation(Location location)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteLocation(Location location)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetAllLocations(string city = "")
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsByLocationSearch(LocationSearch location)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsPerPatient(string id)
    {
        return Task.FromResult(list.FindAll(x => x.PatientId.Equals(id)));
    }

    public Task<List<Location>> GetLocationByAge(LocationSearch location)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsByDate(LocationSearch location)
    {
        throw new NotImplementedException();
    }
}
