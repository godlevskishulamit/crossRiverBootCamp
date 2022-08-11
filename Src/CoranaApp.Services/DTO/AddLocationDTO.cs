namespace CoronaApp.Services.DTO;

public class AddLocationDTO
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Adress { get; set; }

    [Required]
    public string PatientId { get; set; }
}
