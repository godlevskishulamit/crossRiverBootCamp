using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IPatientDal _dal;
        public PatientRepository(IPatientDal dal)
        {
            _dal = dal;
        }
    
        public Task<Patient> GetAsync(ClaimsPrincipal user)
        {
             return _dal.GetAsync(user);
        }

        public Task SaveAsync(Patient patient)
        {
           return  _dal.SaveAsync(patient);
        }
    }
}
