
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Mvc;
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
        void postExposure(int id, Location location);
        Task<List<Location>> getByUserId(int id);
        Task<List<Location>> getByCity(string city);
        Task<List<Location>> getAllLocations();




    }
}
