namespace CoronaApp.Services.DTO
{
    public record PatientDTO
    {
        [Required]
        [RegularExpression("^[0-9]{9}$")]
        public string Id { get; set; }
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 120)]
        public int Age { get; set; }
    }
}
