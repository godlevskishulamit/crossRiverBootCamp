using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;

namespace CoronaApp.Api;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        CreateMap<User, UserDTO>();
        CreateMap<PostLocationDTO, Location>();
        /*CreateMap<PostPatientDTO, Patient>();*/

    }
}
