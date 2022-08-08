using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal.Interfaces;

public interface IDalLocation
{
    Task<List<Location>> getAllLocations();
    Task<List<Location>> getLocationsById(string id);
    Task<Location> postLocation(Location loc);
    Task<List<Location>> getLocationByCity(string city);
    Task<List<Location>> getByFilteredData(LocationSearch location);
}