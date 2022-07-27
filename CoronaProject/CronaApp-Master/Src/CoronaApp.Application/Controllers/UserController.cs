using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserDal _userDal;

        public UserController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpPost]
        public async Task PostUser([FromBody] User user)
        {
            await _userDal.PostUser(user);
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateToken(string userName, string password)
        {
            var token  = await _userDal.CreateToken(userName, password);
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(token);
        }
        /*[HttpGet("userName")]
        public string getUserName()
        {
            return _userDal.getUserName();
        }*/
    }
}
