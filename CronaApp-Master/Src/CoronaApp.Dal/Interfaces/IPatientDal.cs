using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Interfaces
{
    public interface IPatientDal
    {
        Task SaveAsync(Patient patient);
        Task<Patient> GetAsync(ClaimsPrincipal user);
    }
}
