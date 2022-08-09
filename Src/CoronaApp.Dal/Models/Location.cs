namespace CoronaApp.Dal.Models;

public class Location : IComparable<Location>
{
    [Key]
    public int Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }

    [StringLength(9)]
    public string PatientId { get; set; }



    public int CompareTo(Location other)
    {
        return (this.StartDate != other.StartDate) ?
            ((this.StartDate < other.StartDate) ? 1 : -1) : 0;
    }
}