using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CoronaApp.Dal.Models;
public class Location : IComparable<Location>
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
    public string PatientId { get; set; }
    public int CompareTo(Location other)
    {
        return (this.StartDate != other.StartDate) ?
            ((this.StartDate < other.StartDate) ? 1 : -1) : 0;
    }
    public Location()
    {

    }
    public Location(int id, DateTime start, DateTime end, string city, string adress, string patientId)
    {
        this.Id = id;
        this.StartDate = start;
        this.EndDate = end;
        this.City = city;
        this.Adress = adress;
        this.PatientId = patientId;
        this.Patient = null;
    }
}