using AutoMapper;

namespace CoronaApp.Api.Profiles;

public class AutoMap : Profile
{
    public AutoMap()
    {
        CreateMap<Location, LocationPostDto>().ReverseMap();
        CreateMap<Location, LocationGetByIdDto>().ReverseMap();
    }
}
