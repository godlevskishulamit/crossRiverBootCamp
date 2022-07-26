using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Tests
{
    public class MockLocationDal : ILocationDal
    {
        Patient p1;
        Patient p2;
        Location l1;
        Location l2;
        Location l3;
        public  List<Location> DB;
        public MockLocationDal()
        {
            p1 = new Patient() { Id = "111", Name = "Shira", Age = 20 };
            p2 = new Patient() { Id = "222", Name = "Chanchy", Age = 20 };
            l1 = new Location()
            {
                Id = 1,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                City = "TLV",
                Address = "Riding",
                PatientId = "111"
            };
            l2 = new Location()
            {
                Id = 3,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                City = "JLM",
                Address = "Malha",
                PatientId = "111"
            }; l3 = new Location()
            {
                Id = 2,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                City = "JLM",
                Address = "Mamilla",
                PatientId = "222"
            };
            DB = new List<Location>();
            DB.Add(l1);
            DB.Add(l2);
            DB.Add(l3);
        }
        public static List<Patient> patients;
        public Task<int> addNewLocation(Location newLocation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> getAllLocation()
        {
            return await Task.FromResult(DB);
        }

        public Task<List<Location>> getAllLocationByCity(string city)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getFilteredLOcation(LocationSearch locationSearch)
        {
            throw new NotImplementedException();
        }

        public Task<List<Location>> getLocationsByPatientId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
