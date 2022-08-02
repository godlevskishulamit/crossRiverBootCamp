using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<string> CreateToken(UserDTO user);
        Task PostUser(UserDTO user);
        string GetUserName(ClaimsPrincipal user);
    }
}
