using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers;

/*[Authorize]*/
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    IUserRepository _IUser;
    public UserController(IUserRepository IUser)
    {
        _IUser = IUser;
    }
    // Post: User
    [HttpPost("logIn")]
    public async Task<string> logIn([FromBody] User newUser)
    {
        return await _IUser.logIn(newUser);
    }

    // Post: User
    [HttpPost("signUp")]
    public async Task<string> signUp([FromBody] User newUser)
    {
        return await _IUser.signUp(newUser);
    }
}
