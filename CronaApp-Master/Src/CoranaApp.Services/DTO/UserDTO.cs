using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.DTO;

public class UserDTO
{
    public int Id { get; set; }
    [EmailAddress]
    [Required]
    public string Name { get; set; }
    public string Token { get; set; }
}
