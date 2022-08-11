namespace CoronaApp.Services.Classes;
public class LocationService : ILocationService
{
    private readonly ILocationDAL _locationDal;
    IMapper mapper;
    public LocationService(ILocationDAL locationDal)
    {
        _locationDal = locationDal;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
    }
    public async Task<List<LocationDTO>> GetAllLocations(string city = "")
    {
        List<Location> res = await _locationDal.GetAllLocations(city);
        return mapper.Map<List<Location>, List<LocationDTO>>(res);
    }
    public async Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch locationSearch)
    {
        List<Location> dateList=new List<Location>(),ageList = new List<Location>();
        if (locationSearch.StartDate == null && locationSearch.EndDate == null && locationSearch.Age == null)
            throw new ArgumentNullException(nameof(locationSearch));
        if (locationSearch.StartDate > locationSearch.EndDate||locationSearch.EndDate>DateTime.Now)
            throw new ArgumentException("arguments of dates is worng!!");
        if (locationSearch.StartDate != null && locationSearch.EndDate == null)
            locationSearch.EndDate = DateTime.Now;
        if (locationSearch.StartDate == null && locationSearch.EndDate != null)
            locationSearch.StartDate = locationSearch.EndDate;
        if (locationSearch.StartDate != null)
            dateList=await _locationDal.GetLocationsByDate(locationSearch);
        if (locationSearch.Age != null) 
            ageList=await _locationDal.GetLocationByAge(locationSearch);
        return mapper.Map<List<LocationDTO>>(dateList.Union(ageList).ToList());
    }
    public async Task<List<LocationDTO>> GetLocationsPerPatient(string id)
    {
        return mapper.Map<List<LocationDTO>>(await _locationDal.GetLocationsPerPatient(id));
    }
    public async Task<bool> AddLocation(LocationDTO location)
    {
        return await _locationDal.AddLocation(mapper.Map<LocationDTO,Location>(location));
    }
    public async Task<bool> DeleteLocation(int id)
    {
        return await _locationDal.DeleteLocation(id);
    }
}
