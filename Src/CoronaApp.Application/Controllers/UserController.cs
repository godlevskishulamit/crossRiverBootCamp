using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
    public async Task<ActionResult<string>> logIn([FromBody] User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException("newUser");
        }
        var result =  await _IUser.logIn(newUser);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // Post: User
    [HttpPost("signUp")]
    public async Task<ActionResult<string>> signUp([FromBody] User newUser)
    {
        if (newUser == null)
        {
            throw new ArgumentNullException("newUser");
        }
        var result =  await _IUser.signUp(newUser);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }
}
