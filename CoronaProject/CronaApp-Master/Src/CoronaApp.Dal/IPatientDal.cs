using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IPatientDal
{
    Task<List<Location>> GetPatientLocations(string patintId);
    Task PostPatient(Patient patient);
}