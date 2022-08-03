using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Interfaces;

public interface IDalUser
{
    Task<User> getUser(UserDTO user);
    Task PostUser(UserDTO user);
}