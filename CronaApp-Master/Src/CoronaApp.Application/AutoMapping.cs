using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;

namespace CoronaApp.Api;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        CreateMap<User, UserDTO>()
                .ForMember(des => des.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(des => des.Id, opts => opts.MapFrom(src => src.Id));
    }
}
