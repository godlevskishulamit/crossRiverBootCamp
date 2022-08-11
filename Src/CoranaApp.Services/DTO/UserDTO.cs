namespace CoronaApp.Services.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
