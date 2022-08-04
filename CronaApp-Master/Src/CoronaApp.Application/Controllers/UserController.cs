using Microsoft.AspNetCore.Mvc;
using CoronaApp.Services.Models;
using System.Threading.Tasks;
using CoronaApp.Services;
using AutoMapper;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    IUserService _userService;
 
    public UserController(IUserService userService)
    {
        _userService = userService;
      
    }
    [HttpPost("login")]
    public async Task<ActionResult<string>> LogIn([FromBody] UserLoginDTO user)
    {

        UserDTO userToken = await _userService.Login(user);
        if (userToken == null)
        {
            return StatusCode(204, "There is no such user");
        }
        return Ok(userToken);
    }
    [HttpPost("signUp")]
    public async Task<ActionResult<string>> SignUp([FromBody] UserLoginDTO user)
    {
        UserDTO userToken = await _userService.SignUp(user);
        return Ok(userToken.Token);
    }

}

