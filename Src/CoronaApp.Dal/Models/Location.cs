namespace CoronaApp.Dal.Models;
public class Location : IComparable<Location>
{
    public int Id { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    [Required]
    [MinLength(3)]
    public string City { get; set; }
    [Required]
    [MinLength(3)]
    public string Adress { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
    [Required]
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