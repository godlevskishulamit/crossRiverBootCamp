namespace CoronaApp.Services.DTO;

public class AddLocationDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }
    public string PatientId { get; set; }
}
