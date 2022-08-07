using CoronaApp.Dal.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        public  Task<string> logIn(User newUser);
        Task<string> signUp(User newUser);
        public  Task<string> GetUserName(ClaimsPrincipal User);

    }
}