using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Classes
{
    public class LocationDAL : ILocationDAL
    {
        private readonly CoronaContext _context;
        public LocationDAL(CoronaContext context)
        {
            _context = context;
        }
        public async Task<List<Location>> GetAllLocations(string city = "")
        {
            List<Location> locations = await _context.Location.ToListAsync();
            List<Location> result = new List<Location>();
            result.AddRange(locations.FindAll(x => x.City.ToLower().Contains(city.ToLower())));
            result.Sort();
            return result;
        }

        public async Task<List<Location>> GetLocationsByDate(LocationSearch location)
        {
            List<Location> locations = await _context.Location.ToListAsync();
            List<Location> result = new List<Location>();

            result = locations.FindAll(x =>
            ((x.StartDate <= location.StartDate) && (x.EndDate >= location.StartDate)) ||
            ((x.EndDate >= location.EndDate) && (x.StartDate <= location.EndDate)) ||
            ((x.StartDate >= location.StartDate) && (x.StartDate <= location.EndDate)));

            return result;
        }
        public async Task<List<Location>> GetLocationByAge(LocationSearch location)
        {
            List<Location> result = new List<Location>();
            List<Location> locations = await _context.Location.ToListAsync();
            List<Patient> allPatients = await _context.Patient.ToListAsync();
            List<Patient> patients = new List<Patient>();
            patients.AddRange(allPatients.FindAll(x => x.Age==location.Age));
            List<string> patientsId = new List<string>();
            patients.ForEach(x => patientsId.Add(x.Id));
            result = locations.FindAll(x => patientsId.IndexOf(x.PatientId)!=-1);
            return result;
        }

        public async Task<List<Location>> GetLocationsPerPatient(string id)
        {
            List<Location> list = await _context.Location.ToListAsync();
            List<Location> p = list.FindAll(x => x.PatientId.Equals(id));
            return p;
        }
        public async Task AddLocation(Location location)
        {
            //List<Patient> patients=await _context.Patient.ToListAsync();
            //Patient p=patients.Find(x => x.Id.Equals(location.PatientId));
            //location.Patient = p;
            await _context.Location.AddAsync(location);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteLocation(Location location)
        {
            _context.Location.Remove(location);
            await _context.SaveChangesAsync();
        }
    }
}
