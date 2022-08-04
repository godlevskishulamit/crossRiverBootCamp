using AutoMapper;
using CoronaApp.Dal.DTO;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Mappers
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationDTO, Location>().ReverseMap();
        }


    }
}
