using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Services
{
    public class LocationDal:ILocationDal
    {

        CoronaContext db;

        public LocationDal(CoronaContext _db)
        {
            db = _db;
        }

        public async Task<List<Location>> getAllLocations()
        {
            return await db.Locations.ToListAsync();
        }


        public async Task<List<Location>> getByCity(string city)
        {
            return await db.Locations.Where(l => l.City == city).ToListAsync();

        }

        public async Task<List<Location>> getByUserId(int id)
        {
            return await db.Locations.Where(l => l.PatientId == id).ToListAsync();
        }

        public async void postExposure(int id, Location location)
        {
                if (db.Patients.FirstOrDefault(p => p.PatientId == id) == null)
            {
                await db.Patients.AddAsync(new Patient() { PatientId = id }); ;
            }
           
            await db.Locations.AddAsync(location);
            db.SaveChanges();

        }

        public async Task<List<Location>> getByDate(DateTime startDate, DateTime endDate)
        {
            return await db.Locations.Where(l => DateTime.Compare(startDate, l.StartDate) >= 0 && DateTime.Compare(endDate, l.EndDate) <= 0).ToListAsync();

        }
        public async Task<List<Location>> getByAge(int age)
        {

            List<Location> result = new List<Location>();
            List<Location> final = new List<Location>();
            List<Patient> patients = await db.Patients.Where(p => p.Age == age).ToListAsync();
            foreach (Patient patient in patients)
            {
                result = db.Locations.Where(l => l.PatientId == patient.PatientId).ToList();
                foreach (Location location in result)
                {
                    final.Add(location);
                }
            }

            return final;
        }

    }
}
