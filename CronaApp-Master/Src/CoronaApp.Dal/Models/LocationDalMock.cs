using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models
{
    class LocationDalMock : ILocationDal
    {
        Task ILocationDal.Delete(string patientId, int locationId)
        {
            throw new NotImplementedException();
        }
        
        Task<ICollection<Location>> ILocationDal.GetAllLocation()
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationDal.GetLocationsByCity(string city)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationDal.GetLocationsByDate(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationDal.GetLocationsByDateAndPatientAge(DateTime? startDate, DateTime? endDate, int? age)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationDal.GetLocationsByPatientAge(int? age)
        {
            throw new NotImplementedException();
        }

        Task<List<Location>> ILocationDal.GetLocationsByPatientId(string PatientId)
        {
            throw new NotImplementedException();
        }

        Task ILocationDal.PostLocation(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
