namespace CoronaApp.Services.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        [MinLength(3)]
        public string City { get; set; }
        [Required]
        [MinLength(3)]
        public string Adress { get; set; }
        [Required]
        public string PatientId { get; set; }
    }
}
