using System;
using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Dto;

namespace CoronaApp.Api
{
    public class LocationProfiler:Profile
    {
        public LocationProfiler()
        {
            CreateMap<Location, LocationPostDto>().ReverseMap();
        }
        
    }
}

