namespace CoronaApp.Dal.Classes;

public class PatientDAL : IPatientDAL
{
    public PatientDAL()
    {

    }
    public async Task<bool> AddPatient(Patient patient)
    {
        try
        {
            using (CoronaContext context = new CoronaContext())
            {
                await context.Patient.AddAsync(patient);
                await context.SaveChangesAsync();
                return true;
            }

        }
        catch
        {
            return false;
        }
    }
}