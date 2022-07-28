using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Services
{
    public class LocationDal : ILocationDal
    {

        private readonly IConfiguration _configuration;

        public LocationDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Location>> getAllLocationsAsync()
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return await db.Locations.ToListAsync();
            }

        }


        public async Task<List<Location>> getByCityAsync(string city)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return await db.Locations.Where(l => l.City == city).ToListAsync();
            }


        }

        public async Task<List<Location>> getByUserIdAsync(string id)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return await db.Locations.Where(l => l.PatientId.Equals(id)).ToListAsync();
            }

        }

        public async void postExposure(string id, Location location)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                if (db.Patients.FirstOrDefault(p => p.PatientId.Equals(id)) == null)
                {
                    await db.Patients.AddAsync(new Patient() { PatientId = id }); ;
                }

                await db.Locations.AddAsync(location);
                db.SaveChanges();
            }


        }

        public async Task<List<Location>> getByDateAsync(DateTime startDate, DateTime endDate)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return await db.Locations.Where(l => DateTime.Compare(startDate, l.StartDate) >= 0 && DateTime.Compare(endDate, l.EndDate) <= 0).ToListAsync();
            }

        }
        public async Task<List<Location>> getByAgeAsync(int age)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                List<Location> result = new List<Location>();
                List<Location> final = new List<Location>();
                List<Patient> patients = await db.Patients.Where(p => p.Age == age).ToListAsync();
                foreach (Patient patient in patients)
                {
                    result = db.Locations.Where(l => l.PatientId.Equals(patient.PatientId)).ToList();
                    foreach (Location location in result)
                    {
                        final.Add(location);
                    }
                }

                return final;
            }

        }

    }
}
