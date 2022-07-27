using CoronaApp.Dal.Models;
using CoronaApp.Services.Classes;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var token = await _loginService.Login(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var token = await _loginService.SignUp(user);
            if (token == null)
            {
                return Unauthorized();
            }
            if (token == "")
            {
                return BadRequest("Adding user failed! try again later...");
            }
            return Ok(token);
        }
        
    }
}
