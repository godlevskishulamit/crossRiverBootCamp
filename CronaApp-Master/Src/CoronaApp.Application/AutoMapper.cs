using AutoMapper;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Models;

namespace CoronaApp.Api
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Location , LocationPostDTO> ()
                .ReverseMap();
        }
    }
}
