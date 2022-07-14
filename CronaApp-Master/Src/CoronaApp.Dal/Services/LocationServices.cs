using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Services
{
    public class LocationServices
    {

       CoronaContext db;
        public LocationServices(CoronaContext _db)
        {
            db = _db;
        }

        public static async Task<List<Location>> getAllLocations()
        {
            using (var context = new CoronaContext())
            {
                return await context.Locations.ToListAsync();
            }
    }

        public static async Task<List<Location>> getByCity(string city)
        {
            using (var context = new CoronaContext())
            {
                return await context.Locations.Where(l => l.City == city).ToListAsync();
            }
        }

        public static async Task< List<Location>> getByPatientId(int id)
        {
            using (var context = new CoronaContext())
            {
                return await context.Locations.Where(l => l.PatientId== id).ToListAsync();
            }
        }

        public static async void postExposure(Location location, int id)
        {
            using (var context = new CoronaContext())
            {
                if (context.Patients.FirstOrDefault(p => p.PatientId == id)==null)
                {
                  await context.Patients.AddAsync(new Patient() { PatientId=id}); ;
                }
                await context.Locations.AddAsync(location);
                context.SaveChanges();
            }

        }

        public static async Task<List<Location>> getByDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new CoronaContext())
            {

                //return await context.Locations.Where(l => l.StartDate>=startDate||l.EndDate<=endDate).ToListAsync();

              return await context.Locations.Where(l=>DateTime.Compare(startDate,l.StartDate)>=0&&DateTime.Compare(endDate, l.EndDate) <= 0).ToListAsync();
            }
        }
        public static async Task<List<Location>> getByAge(int age)
        {
            using (var context = new CoronaContext())
            {
                List<Location> result = new List<Location>();
                List<Location> final=new List<Location>();
                List<Patient> patients = await context.Patients.Where(p => p.Age == age).ToListAsync();
               foreach(Patient patient in patients)
                {
                  result=context.Locations.Where(l =>l.PatientId==patient.PatientId).ToList();
                  foreach(Location location in result)
                    {
                        final.Add(location);
                    }
                }

                return final;
            }
        }
    }
}
