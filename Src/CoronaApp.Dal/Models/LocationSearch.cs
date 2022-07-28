using System;

namespace CoronaApp.Dal.Models;
public class LocationSearch
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Age { get; set; }
    public LocationSearch()
    {
        StartDate = DateTime.Today;
        EndDate = DateTime.Today;
        Age = 0;
    }
}
