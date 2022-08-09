using System;
using System.Collections.Generic;
using CoronaApp.Dal.Models;

using System.Threading.Tasks;

namespace CoronaApp.Dal;
   
    public interface ILocationRepository
    {
        Task<ICollection<Location>> GetAllLocation();
        Task<List<Location>> GetLocationsByCity(string city);
        Task<List<Location>> GetLocationsByPatientId(string PatientId);
        Task<List<Location>> GetLocationsByDate(DateTime? startDate, DateTime? endDate);
        Task<List<Location>> GetLocationsByPatientAge(int? age);
        Task<List<Location>> GetLocationsByDateAndPatientAge(DateTime? startDate, DateTime? endDate, int? age);
        Task PostLocation(Location location);
        Task Delete(string patientId, int locationId);
    }

