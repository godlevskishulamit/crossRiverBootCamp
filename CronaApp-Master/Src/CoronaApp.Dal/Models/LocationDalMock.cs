using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models;
    class LocationDalMock : ILocationRepository
    {
        Task ILocationRepository.Delete(string patientId, int locationId)
        {
            throw new NotImplementedException();
        }
        
        Task<ICollection<Location>> ILocationRepository.GetAllLocation()
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationRepository.GetLocationsByCity(string city)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationRepository.GetLocationsByDate(DateTime?  startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationRepository.GetLocationsByDateAndPatientAge(DateTime? startDate, DateTime? endDate, int? age)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationRepository.GetLocationsByPatientAge(int? age)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationRepository.GetLocationsByPatientId(string PatientId)
        {
            throw new NotImplementedException();
        }

        Task ILocationRepository.PostLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }

