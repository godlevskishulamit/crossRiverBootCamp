using AutoMapper;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;

namespace CoronaApp.Api
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(des => des.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(des => des.ID, opts => opts.MapFrom(src => src.ID));
        }
    }
}
