using CoronaApp.Dal.Models;
using CoronaApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        public Task<ICollection<Location>> GetAllAsync();
        public Task<ICollection<LocationGetByIdDto>> GetByPatientIdAsync(ClaimsPrincipal user);
        public Task<ICollection<Location>> GetByCityAsync(string? city);
        public Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch locationSearch);
        public Task<ICollection<Location>> GetByAgeAsync(int age);
        public Task PostAsync(LocationPostDto location, ClaimsPrincipal user);
        Task<ICollection<Location>> GetByLocationSearchAsync(Models.LocationSearch locationSearch);
    }
}
