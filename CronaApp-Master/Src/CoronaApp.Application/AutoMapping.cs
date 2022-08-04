using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;

namespace CoronaApp.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Location, LocationDTO>()/*.IncludeMembers(location=>location.Patient)*/.ReverseMap();
            // CreateMap<Dal.Models.Patient, LocationDTO>().ReverseMap();
            CreateMap<Location, LocationDTOPost>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
        }
    }
}
