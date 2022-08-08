using System;

namespace CoronaApp.Dal.Models;

public class LocationSearch
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Age { get; set; }
}