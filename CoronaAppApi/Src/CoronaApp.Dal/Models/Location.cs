using System;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models;

public class Location
{
    public int Id { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    [Required]
    public Patient? Patient { get; set; }
}