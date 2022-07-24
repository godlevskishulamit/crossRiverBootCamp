using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface ILocationDal
    {
        Task Delete(Location location);
        Task<List<Location>> GetByAge(LocationSearch locationSearch);
        Task<List<Location>> GetByCity(string city = "");
        Task<List<Location>> GetByLocationSearch(LocationSearch locationSearch);
        Task<List<Location>> GetByPatientId(string id);
        Task Post(Location location);
        Task Put(Location location);
    }
}