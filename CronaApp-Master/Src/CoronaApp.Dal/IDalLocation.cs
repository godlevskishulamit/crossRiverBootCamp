using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal;

public interface IDalLocation
{
    Task<List<Location>> getAllLocations();
    Task<List<Location>> getLocationsById(string id);
    Task postLocation(Location loc);
    Task<List<Location>> getLocationByCity(string city);
    Task<List<Location>> getByAge(int age);
    Task<List<Location>> getByDate(DateTime sdate,DateTime edate);
}