using CoronaApp.Dal.DTO;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;

public interface ILocationRepository
{
    Task<List<LocationDTO>> Get();
    Task<List<LocationDTO>> getLocationsById(string id);
    Task postLocation(Location loc);
    Task<List<LocationDTO>> getLocationByCity(string city);
    Task<List<LocationDTO>> GetByAge(int age);
    Task<List<LocationDTO>> GetByDate(DateTime sdate, DateTime eDate);
}
