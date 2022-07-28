using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public  class PatientDal : IPatientDal
{

    public async Task<string> addNewPatient(Patient newPatient)
    { 
        try
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                await _CoronaAppDBContext.Patients.AddAsync(newPatient);
                await _CoronaAppDBContext.SaveChangesAsync();
                return newPatient.Id;
            }
        }
        catch (Exception)
        {
            throw new Exception("internal error with SaveChangesAsync function");
        }

    }

}
