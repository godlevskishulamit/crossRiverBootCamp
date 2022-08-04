using CoronaApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IUserRepository
{
    Task PostUser(User user);
    Task<string> CreateToken(string userName, string password);
    Task<string> getUserName(ClaimsPrincipal user);
}
