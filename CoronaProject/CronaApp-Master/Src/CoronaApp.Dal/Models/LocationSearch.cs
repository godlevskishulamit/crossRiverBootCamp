using System;

namespace CoronaApp.Dal.Models;

public class LocationSearch
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int Age { get; set; }
}