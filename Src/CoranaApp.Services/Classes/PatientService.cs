namespace CoronaApp.Services.Classes;

public class PatientService : IPatientService
{
    private readonly IPatientDAL _patientDal;
    IMapper mapper;
    public PatientService(IPatientDAL patientDal)
    {
        _patientDal = patientDal;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
    }
    public async Task<bool> AddPatient(PatientDTO patientDto)
    {
        Patient patient = mapper.Map<Patient>(patientDto);
        return await _patientDal.AddPatient(patient);
    }
}
