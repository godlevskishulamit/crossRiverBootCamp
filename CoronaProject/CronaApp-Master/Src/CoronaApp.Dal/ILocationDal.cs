using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface ILocationDal
{
    Task<List<Location>> GetAllLocations();
    Task<List<Location>> GetLocationsByCity(string city);
    Task<List<Location>> GetLocationsByDate(LocationSearch locationSearch);
    Task<List<Location>> GetLocationsByAge(LocationSearch locationSearch);
    Task PostLocation(Location location);
    Task DeleteLocation(int locationId);
}
