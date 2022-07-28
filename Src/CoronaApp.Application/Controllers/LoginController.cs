using CoronaApp.Dal.Models;
using CoronaApp.Services.Classes;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Security.Claims;
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
            try
            {
                var token = await _loginService.Login(user);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            try
            {
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetUserNameFromToken")]
        public IActionResult GetUserNameFromToken()
        {
            try
            {
                var userName = User.Claims.FirstOrDefault(
                            x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
                return Ok(userName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
