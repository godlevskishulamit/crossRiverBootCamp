using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(User u);
        Task<string> SignUp(User u);
    }
}