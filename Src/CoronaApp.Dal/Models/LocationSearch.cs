namespace CoronaApp.Dal.Models;
public class LocationSearch
{
    [DataType(DataType.DateTime)]
    public DateTime? StartDate { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? EndDate { get; set; }
    [Range(0,120)]
    public int? Age { get; set; }
}