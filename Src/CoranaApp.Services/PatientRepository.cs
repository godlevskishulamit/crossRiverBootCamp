using CoronaApp.Dal;
using System.Threading.Tasks;

namespace CoronaApp.Services;
public class PatientRepository : IPatientRepository
{
    IPatientDal _PatientDal;
    public PatientRepository(IPatientDal PatientDal)
    {
        _PatientDal = PatientDal;
    }

    public async Task<string> addNewPatient(Patient newPatient)
    {
        return await _PatientDal.addNewPatient(newPatient);
    }
}
