using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
   public class MockLocationDal:ILocationDal
    {
        public Patient p1;
        public Location l1;
        public Location l2;
        public List<Location> db;
        public MockLocationDal()
        {
            p1 = new Patient() { Id = "212625917", Name = "Shira", Age = 20 };
            l1 = new Location() { Id = 1, StartDate = new DateTime(), EndDate = new DateTime(), City = "TLV", Address = "King David 28", PatientId = "212625917" };
            l2 = new Location() { Id = 1, StartDate = new DateTime(), EndDate = new DateTime(), City = "JLM", Address = "King David 28", PatientId = "212625917" };
            db = new List<Location>();
            db.Add(l1);
            db.Add(l2);
        }

        public Task<int> addNewLocation(Location newLocation)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getAllLocation()
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getAllLocationByAge(LocationSearch age)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getAllLocationByCity(string city)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
           return await Task.FromResult(db.Where(location => location.PatientId == id).ToList());
        }
       
    }
}
