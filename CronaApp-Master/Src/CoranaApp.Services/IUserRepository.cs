using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<User> getUser(UserDTO userDTO);
        Task PostUser(UserDTO user);
        string createToken(User user);
    }
}