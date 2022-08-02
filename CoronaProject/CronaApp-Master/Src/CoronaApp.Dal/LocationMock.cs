using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class LocationMock : ILocationDal
{
    public Task DeleteLocation(int locationId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetAllLocations()
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsByAge(LocationSearch locationSearch)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsByCity(string city)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetLocationsByDate(LocationSearch locationSearch)
    {
        throw new NotImplementedException();
    }

    public Task PostLocation(Location location)
    {
        throw new NotImplementedException();
    }
}
