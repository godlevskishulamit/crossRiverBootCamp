using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.DTO;

public class UserLoginDTO
{
    [EmailAddress]
    [Required]
    public string Name { get; set; }
    [MinLength(8)]
    [Required]

    public string Password { get; set; }

}
