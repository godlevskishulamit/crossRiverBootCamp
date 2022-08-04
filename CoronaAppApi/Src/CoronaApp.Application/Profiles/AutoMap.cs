using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Dtos;

namespace CoronaApp.Api.Profiles;

public class AutoMap : Profile
{
    public AutoMap()
    {
        CreateMap<Location, LocationPostDto>().ReverseMap();
        CreateMap<Location, LocationGetByIdDto>().ReverseMap();
    }
}
