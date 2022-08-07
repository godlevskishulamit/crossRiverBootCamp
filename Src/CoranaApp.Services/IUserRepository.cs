using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        public  Task<string> logIn(User newUser);
        Task<string> signUp(User newUser);
    }
}