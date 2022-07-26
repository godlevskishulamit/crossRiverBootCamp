using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IDalUser
{
     Task<User> getUser(UserDTO user);
}