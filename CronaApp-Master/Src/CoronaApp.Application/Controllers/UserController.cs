using CoronaApp.Services;
namespace CoronaApp.Api.Controllers;
using System.Threading.Tasks;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
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
        if (user == null)
            return BadRequest();
        try
        {
            UserDTO userToken = await _userService.Login(user);
            if (userToken == null)
            {
                return StatusCode(204, "There is no such user");
            }
            return Ok(userToken);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost("signUp")]
    public async Task<ActionResult<string>> SignUp([FromBody] UserLoginDTO user)
    {
        if (user == null)
            return BadRequest();
        try
        {
            UserDTO userToken = await _userService.SignUp(user);
            return Ok(userToken.Token);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }

}

