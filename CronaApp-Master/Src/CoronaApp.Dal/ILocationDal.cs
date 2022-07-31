using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

    public interface ILocationDal
    {
        Task<List<Location>> GetByAge(LocationSearch locationSearch);
        Task<List<Location>> GetByCity(string city = "");
        Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch);
        Task<List<Location>> GetByPatientId(string id);
        Task AddNewLocation(Location location);
        Task EditLocation(Location location);
    Task DeleteLocation(Location location);
    }
