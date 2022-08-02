using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface ILocationRepository
{
    Task<List<LocationDTO>> GetAllLocations();
    Task<List<LocationDTO>> GetLocationsByCity(string city);
    Task<List<LocationDTO>> GetLocationsByDate(LocationSearch locationSearch);
    Task<List<LocationDTO>> GetLocationsByAge(LocationSearch locationSearch);
    Task PostLocation(LocationDTO location);
    Task DeleteLocation(int locationId);
}
