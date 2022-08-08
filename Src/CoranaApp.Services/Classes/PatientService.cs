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
    public async Task<bool> AddPatient(PatientDTO patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));
        return await _patientDal.AddPatient(mapper.Map<PatientDTO,Patient>(patient));
    }
}