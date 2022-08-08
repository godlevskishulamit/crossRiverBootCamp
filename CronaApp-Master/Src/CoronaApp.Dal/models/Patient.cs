using System;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Services.Models;

public class Patient
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(9)]
    public string IdNumber { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

}
