using CoronaApp.Dal;

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
    [ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _service;

    public UserController(IUserRepository service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task PostUser([FromBody] User user)
    {
        await _service.PostUser(user);
    }

    [HttpPost("token")]
    public async Task<IActionResult> CreateToken(string userName, string password)
    {
        try { return Json(await _service.CreateToken(userName, password)); }
        catch { throw; }
    }

    [HttpGet("userName")]
    public async Task<IActionResult> GetUserName()
    {
        try { return Ok(await _service.getUserName(User)); }
        catch { throw; }
    }
}
