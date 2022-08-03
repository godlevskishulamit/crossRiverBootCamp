using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.DTO;

public class UserDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
