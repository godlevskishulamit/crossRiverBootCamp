using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models;

public class Location
{
    [Key]
    public int LocaionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [MaxLength(20)]
    public string City { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }

    public string PatientId { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
}