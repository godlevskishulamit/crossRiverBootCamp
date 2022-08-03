using AutoMapper;
using CoronaApp.Dal.DTO;
using CoronaApp.Services.Models;

namespace CoronaApp.Api.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationDTO, Location>()
                .ReverseMap();
        }
    }
}
