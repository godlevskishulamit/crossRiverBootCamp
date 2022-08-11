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
    public async Task<IActionResult> PostToken(UserDTO user)
    {
        if (user.UserName == null || user.Password == null)
            return StatusCode(406, "this user is not acceptable");
        string token = await _userService.GetTokenForUser(user);
        if (string.IsNullOrEmpty(token))
            return Unauthorized(null);
        return Ok(token);
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody]UserDTO user)
    {
        if (user.UserName == null || user.Password == null)
            return StatusCode(406, "this user is not acceptable");
        try
        {
            var token = await _userService.SignUp(user);
            if (token == null)
                return BadRequest("adding user failed... are you sure this user doesn't exist yet?");
            return Ok(token);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
