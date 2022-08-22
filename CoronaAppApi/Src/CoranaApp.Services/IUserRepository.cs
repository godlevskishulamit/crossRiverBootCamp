using CoronaApp.Dal;

namespace CoronaApp.Services;

public interface IUserRepository
{
    Task PostUser(User user);
    Task<string> CreateToken(string userName, string password);
    Task<string> getUserName(ClaimsPrincipal user);
}
