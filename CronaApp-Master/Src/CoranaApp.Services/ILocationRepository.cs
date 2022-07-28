
using CoronaApp.Dal.Models;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
       // ICollection<Location> Get(LocationSearch locationSearch);
        Task<List<Location>> getByAge(int age);
        Task<List<Location>> getByDate(DateTime startDate, DateTime endDate);
        void postExposure(string id, Location location);
        Task<List<Location>> getByUserId(string id);
        Task<List<Location>> getByCity(string city);
        Task<List<Location>> getAllLocations();




    }
}
