
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<User> getUser(UserDTO userDTO);
        Task<string> signUp(UserDTO user);
        string login(User user);
        string createToken(User user);
        Task<string> GetNameByToken(ClaimsPrincipal user);
    }
}