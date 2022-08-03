using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Services.Models;

public class Patient
{
    [Key]
    [Required]
    [MaxLength(9)]
    public string Id { get; set; }
    public string name { get; set; }
    [Range(0,120)]
    public int? age { get; set; }
}