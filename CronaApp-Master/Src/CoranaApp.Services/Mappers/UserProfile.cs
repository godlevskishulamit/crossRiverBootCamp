using AutoMapper;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
        

    }
}
