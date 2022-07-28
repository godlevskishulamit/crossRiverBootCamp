using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;

namespace CoronaApp.Dal.Interfaces
{
   public interface ILocationDal
    {
        Task<List<Location>> getAllLocationsAsync();


        Task<List<Location>> getByCityAsync(string city);


        Task<List<Location>> getByUserIdAsync(string id);


        void postExposure(string id, Location location);

        Task<List<Location>> getByDateAsync(DateTime startDate, DateTime endDate);
        Task<List<Location>> getByAgeAsync(int age);

    }
}
 