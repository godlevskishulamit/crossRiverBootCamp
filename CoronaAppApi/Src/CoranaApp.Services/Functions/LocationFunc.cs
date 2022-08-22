using AutoMapper;
using CoronaApp.Services.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Services.Functions;

public class LocationFunc : ILocationRepository
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public LocationFunc(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<ICollection<Location>> GetAllAsync()
    {
        using (var db = new CoronaContext(_configuration))
        {
            return await db.Locations.ToListAsync();
        //    return new List<Location>();
        }
        
    }
    public async Task<ICollection<LocationGetByIdDto>> GetByPatientIdAsync(ClaimsPrincipal user)
    {
        string id = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;

        using (var db = new CoronaContext(_configuration))
        {
            return _mapper.Map<ICollection<LocationGetByIdDto>>(await db.Locations.Where(l => l.Patient.Id == id).ToListAsync());
        }
    }
    public async Task<ICollection<Location>> GetByCityAsync(string? city)
    {
        using (var db = new CoronaContext(_configuration))
        {
            if ( city != null && city.Length > 0 && city != " ")
                return await db.Locations.Where(l => l.City.Contains(city)).ToListAsync();
            else
                return await db.Locations.ToListAsync();
        }
    }
    public async Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch? locationSearch)
    {
        DateTime? StartDate = locationSearch?.StartDate ?? null;
        DateTime? EndDate = locationSearch?.EndDate ?? null;

        using (var db = new CoronaContext(_configuration))
        {
            return db.Locations.Where(l => 
                    l.StartDate >= (StartDate ?? l.StartDate)
                    //&& 
                    //l.EndDate >= (EndDate ?? l.EndDate)
                ).ToList();
        }
    }
    public async Task<ICollection<Location>> GetByAgeAsync(int age)
    {
        using (CoronaContext db = new CoronaContext(_configuration))
        {
            return db.Locations.Where(l => l.Patient.Age == age).ToList();
        }
    }
    public async Task<ICollection<Location>> GetByLocationSearchAsync(Models.LocationSearch locationSearch)
    {
        ICollection<Location> l1 = await GetByDatesRangeAsync(locationSearch);
        ICollection<Location> l2 = await GetByAgeAsync((int)locationSearch?.Age);
        return l1.Intersect(l2).ToList(); 
    }
    public async Task PostAsync(LocationPostDto location, ClaimsPrincipal user)
    {
        string id = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;

        if (location == null || id == null)
            throw new InvalidOperationException();


        using (var db = new CoronaContext(_configuration))
        {
            Patient Exitpatient = db.Patients.FirstOrDefault(p => p.Id == id);
            Location locationToPost = _mapper.Map<Location>(location);
            locationToPost.Patient = Exitpatient;

            if (Exitpatient == null)
            {
                await db.Locations.AddAsync(locationToPost); //If the patient does'nt exist, he'll be created automatically by this line.
            }
            else
            {
                if (Exitpatient.Locations == null)
                    Exitpatient.Locations = new List<Location>();
                Exitpatient.Locations.Add(locationToPost);
            }

            await db.SaveChangesAsync();
        }
    }
}
