
namespace CoronaApp.Services.Models
{
    public class PatientDTO
    {
        public PatientDTO()
        {

        }
        public PatientDTO(string id)
        {
            Id = id;

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
