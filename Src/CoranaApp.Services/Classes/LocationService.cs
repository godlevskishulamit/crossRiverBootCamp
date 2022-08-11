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
    public async Task<List<LocationDTO>> GetAllLocations()
    {
        List<Location> locations = await _locationDal.GetAllLocations();
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<List<LocationDTO>> GetLocationsByCity(string city = "")
    {
        List<Location> locations = await _locationDal.GetLocationsByCity(city);
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch location)
    {
        List<Location> locationsAge = new List<Location>() , locationsDate = new List<Location>() ;
        if (location.Age != null)
            locationsAge = await _locationDal.GetLocationByAge(location);
        if (location.StartDate != null && location.EndDate != null)
            locationsDate = await _locationDal.GetLocationsByDate(location);
        return mapper.Map<List<LocationDTO>>(locationsAge.Union(locationsDate));
    }
    public async Task<List<LocationDTO>> GetLocationsPerPatient(string id)
    {
        List<Location> locations = await _locationDal.GetLocationsByPatient(id);
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<bool> AddLocation(AddLocationDTO locationDto)
    {
        Location location = mapper.Map<Location>(locationDto);
        return await _locationDal.AddLocation(location);
    }
    public async Task<bool> DeleteLocation(LocationDTO locationDto)
    {
        Location location = mapper.Map<Location>(locationDto);
        return await _locationDal.DeleteLocation(location);
    }
}
