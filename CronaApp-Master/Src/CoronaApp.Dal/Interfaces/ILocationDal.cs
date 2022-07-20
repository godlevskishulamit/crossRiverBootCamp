using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;

namespace CoronaApp.Dal.Interfaces
{
   public interface ILocationDal
    {
        Task<List<Location>> getAllLocations();


        Task<List<Location>> getByCity(string city);


        Task<List<Location>> getByUserId(int id);


        void postExposure(int id, Location location);

        Task<List<Location>> getByDate(DateTime startDate, DateTime endDate);
        Task<List<Location>> getByAge(int age);

    }
}
 