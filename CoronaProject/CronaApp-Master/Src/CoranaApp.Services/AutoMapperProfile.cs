using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Location, LocationDTO>().ReverseMap(); ;
            CreateMap<Patient, PatientDTO>().ReverseMap(); ;
            CreateMap<User, UserDTO>().ForMember(dest =>
                                                dest.UserName,
                                                opt => opt.MapFrom(src => src.Name)).ReverseMap(); ;
        }

    }
}
