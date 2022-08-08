namespace CoronaApp.Services.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [MinLength(3)]
        public string City { get; set; }
        [MinLength(3)]
        public string Adress { get; set; }
        public string PatientId { get; set; }
    }
}
