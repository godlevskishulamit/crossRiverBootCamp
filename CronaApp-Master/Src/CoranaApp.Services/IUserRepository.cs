using CoronaApp.Dal.models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<string> LogIn(User user);
        Task<string> Post(User user);
        HttpContent getUserName(HttpContent httpContext);
    }
}