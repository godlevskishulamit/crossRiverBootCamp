namespace CoronaApp.Services
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ForMember(dest =>
            dest.UserName,
            opt => opt.MapFrom(src => src.Name));
            CreateMap<LocationDTO, Location>().ReverseMap();
            CreateMap<PatientDTO, Patient>();
        }
    }
}
