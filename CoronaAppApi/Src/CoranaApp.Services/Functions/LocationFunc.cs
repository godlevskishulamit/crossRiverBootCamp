using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Functions
{
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
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.ToList();
            }
        }
        public async Task<ICollection<LocationGetByIdDto>> GetByPatientIdAsync(ClaimsPrincipal user)
        {
            string id = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;

            await using (var db = new CoronaContext(_configuration))
            {
                return _mapper.Map<ICollection<LocationGetByIdDto>>( db.Locations.Where(l => l.Patient.Id == id).ToList());
            }
        }
        public async Task<ICollection<Location>> GetByCityAsync(string? city)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                if ( city != null && city.Length > 0 && city != " ")
                    return db.Locations.Where(l => l.City.Contains(city)).ToList();
                else
                    return db.Locations.ToList();
            }
        }
        public async Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch locationSearch)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.Where(l => 
                        l.StartDate >= (locationSearch == null || locationSearch.StartDate == null ? l.StartDate : locationSearch.StartDate) && 
                        l.EndDate <= (locationSearch == null || locationSearch.EndDate == null ? l.EndDate : locationSearch.EndDate)
                    ).ToList();
            }
        }
        public async Task<ICollection<Location>> GetByAgeAsync(int age)
        {
            await using (CoronaContext db = new CoronaContext(_configuration))
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


            await using (var db = new CoronaContext(_configuration))
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
}
