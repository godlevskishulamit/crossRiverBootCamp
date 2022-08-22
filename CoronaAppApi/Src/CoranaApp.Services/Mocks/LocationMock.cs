using CoronaApp.Services.Dtos;
using CoronaApp.Services.Models;

namespace CoronaApp.Services.Mocks;

public class LocationMock : ILocationRepository
{
    public Task<ICollection<Dal.Models.Location>> GetAllAsync()
    {
        return null;
    }

    public Task<ICollection<Dal.Models.Location>> GetByAgeAsync(int age)
    {
        return null;
    }

    public Task<ICollection<Dal.Models.Location>> GetByCityAsync(string? city)
    {
        return null;
    }

    public Task<ICollection<Dal.Models.Location>> GetByDatesRangeAsync(LocationSearch locationSearch)
    {
        return null;
    }

    public Task<ICollection<Dal.Models.Location>> GetByLocationSearchAsync(LocationSearch locationSearch)
    {
        return null;
    }

    public Task<ICollection<LocationGetByIdDto>> GetByPatientIdAsync(ClaimsPrincipal user)
    {
        return null;
    }

    public Task PostAsync(LocationPostDto location, ClaimsPrincipal user)
    {
        return null;
    }
}
