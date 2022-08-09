namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    public IConfiguration _configuration;
    private readonly IUserService _userService;

    public LoginController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost]
    [Route("PostToken")]
    public async Task<IActionResult> PostToken(UserDTO userData)
    {
        if (userData != null)
        {
            return Ok(await _userService.GetTokenForUser(userData));
        }
        else
        {
            return BadRequest(null);
        }
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody]UserDTO userDto)
    {
        try
        {
            var token = await _userService.SignUp(userDto);
            if (token == null)
                return BadRequest("adding user failed...");
            return Ok(token);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
