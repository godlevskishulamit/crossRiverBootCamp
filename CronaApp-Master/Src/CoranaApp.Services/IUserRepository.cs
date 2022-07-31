using CoronaApp.Dal.models;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<string> LogIn(User user);
        Task<string> AddNewUser(User user);
        string GetUserName(ClaimsPrincipal user);
    }
}