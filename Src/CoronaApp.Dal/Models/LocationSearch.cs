using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models;

public class LocationSearch
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Column(TypeName="tinyint")]
    [Range(0, 120)]
    public int? Age { get; set; }
}