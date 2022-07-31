using CoronaApp.Dal.models;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

    public interface IUserDal
    {
        Task<User> LogIn(User user);
        Task AddNewUser(User user);
    }
