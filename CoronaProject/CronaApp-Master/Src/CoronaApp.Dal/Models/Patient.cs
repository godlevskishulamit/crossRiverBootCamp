using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models;

public class Patient
{
    [Key]
    [MaxLength(9)]
    [Required]
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}