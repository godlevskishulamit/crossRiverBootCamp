using CoronaApp.Dal.DTO;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;

public interface ILocationRepository
{
    Task<List<Location>> Get();
    Task<List<Location>> getLocationsById(string id);
    Task<Location> postLocation(LocationDTO loc);
    Task<List<Location>> getLocationByCity(string city);
    Task<List<Location>> GetByAge(int age);
    Task<List<Location>> GetByDate(DateTime sdate, DateTime eDate);
    Task<List<Location>> GetByFilteredData(LocationSearch location);
}
