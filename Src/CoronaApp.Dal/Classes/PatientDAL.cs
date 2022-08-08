namespace CoronaApp.Dal.Classes;
public class PatientDAL : IPatientDAL
{
    public async Task<bool> AddPatient(Patient patient)
    {
        try
        {
            using (var _context = new CoronaContext())
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}