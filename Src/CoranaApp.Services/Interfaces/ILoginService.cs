using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(UserDTO u);
        Task<string> SignUp(UserDTO u);
        string GetUserNameFromToken(ClaimsPrincipal token);
    }
}