
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.DTO
{
   public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LocationDTO, Location>().ReverseMap();

            CreateMap<AddLocationDTO, Location>().ReverseMap();

            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<PatientDTO, Patient>().ReverseMap();
        }
        
    }
}