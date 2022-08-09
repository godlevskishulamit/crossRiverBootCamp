using CoronaApp.Dal.models;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        
        Task<List<Location>> GetByCity(string city);
        Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch);
        Task<List<Location>> GetByPatientId(string id);
        Task AddNewLocation(LocationPostDTO location);
        Task EditLocation(Location location);
        Task DeleteLocation(Location location);
    }
}