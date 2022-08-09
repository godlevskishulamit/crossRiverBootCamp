using CoronaApp.Services.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services;
    public interface IUserService
    {
    Task<UserDTO> Login(UserLoginDTO userLogin);
    Task<UserDTO> SignUp(UserLoginDTO userLogin);
    }

