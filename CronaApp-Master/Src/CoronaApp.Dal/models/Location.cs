using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models;

public class Location
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int PatientId { get; set; }
    [ForeignKey("PatientId")]

    public virtual Patient Patient { get; set; }


}
