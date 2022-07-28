using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models;

public class LocationSearch
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Column(TypeName="tinyint")]
    public int? Age { get; set; }
}