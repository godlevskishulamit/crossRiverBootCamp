using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public  class PatientDal : IPatientDal
{
    CoronaAppContext _CoronaAppDBContext;
    public PatientDal(CoronaAppContext CoronaAppDBContext)
    {
        _CoronaAppDBContext =CoronaAppDBContext;
    }
    public async Task<string> addNewPatient(Patient newPatient)
    {
        await _CoronaAppDBContext.Patients.AddAsync(newPatient);
        await _CoronaAppDBContext.SaveChangesAsync();
        return newPatient.Id;
    }

}
