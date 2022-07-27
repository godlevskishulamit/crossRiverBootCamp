using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRepository:IPatientRepository
    {
        private readonly IPatientDal _patientDal;
        public PatientRepository(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        //A function that return locations by patintId
        public async Task<List<Location>> GetPatientLocations(string patintId)
        {
            return await _patientDal.GetPatientLocations(patintId);
        }

        //A function that add location
        public async Task PostLocation(Location location)
        { 
            await _patientDal.PostLocation(location);
        }

        //A function that delete location by patintId
        public async Task DeleteLocation(int locationId)
        {
            await _patientDal.DeleteLocation(locationId);
        }

        //A function that add patient
        public async Task PostPatient(Patient patient)
        {
            await _patientDal.PostPatient(patient);
        }
    }
}
