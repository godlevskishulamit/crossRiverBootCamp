using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] UserDTO user)
        {
            var token  = await _userRepository.CreateToken(user);
            return token != null ? Json(token) : 
                BadRequest(new { message = "Username or password is incorrect" });
          

        }

        [HttpPost]
        public async Task PostUser([FromBody] UserDTO user)
        {
            await _userRepository.PostUser(user);
        }

        [Authorize]
        [HttpGet("getUserName")]
        public ActionResult GetUserName()
        {
            var userName = _userRepository.GetUserName(User);         
            return userName != null ? Ok(userName) :
                  BadRequest(new { message = "Username not found!" });

        }
    }
}
