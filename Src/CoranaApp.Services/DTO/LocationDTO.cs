namespace CoronaApp.Services.DTO;

public  class LocationDTO
{
    [Required]
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }
    public string PatientId { get; set; }

}
