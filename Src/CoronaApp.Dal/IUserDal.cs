using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public interface IUserDal
{
    public Task<User> logIn(User newUser);
    public Task signUp(User newUser);
}