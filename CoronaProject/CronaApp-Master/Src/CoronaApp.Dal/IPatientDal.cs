using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IPatientDal
{
    Task<List<Location>> GetPatientLocations(string patintId);
    Task PostLocation( Location location);
    Task DeleteLocation(int locationId);
    Task PostPatient(Patient patient);
}