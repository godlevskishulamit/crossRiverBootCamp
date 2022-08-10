using CoronaApp.Dal;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class AutoMapperProfile:AutoMapper.Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Location, LocationDto>().ReverseMap();
       /* CreateMap<Location, LocationDto>();*/
    }
}
