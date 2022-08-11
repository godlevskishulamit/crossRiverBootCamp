namespace CoronaApp.Services.DTO;

public class AddLocationDTO
{
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Adress { get; set; }

    [Required]
    [StringLength(9)]
    public string PatientId { get; set; }
}
