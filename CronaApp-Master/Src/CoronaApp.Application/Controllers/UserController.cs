using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoronaApp.Dal.Functions;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

u

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private IConfiguration _configuration;

        public UserController(IUserRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration =configuration;
        }

        [HttpPost]
        public async Task<IActionResult> signIn(User _user)
        {
            if (_user.UserId != null && _user.Password != null && _user.UserName != null)
            {
                var user = await GetUser(_user.UserId, _user.Password, _user.UserName);
            }
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", _user.UserId.ToString()),
                    new Claim("Password", _user.Password),
                    new Claim("Name", _user.UserName)
                };
            }
        }

        [HttpGet]
        public async Task<User> GetUser(int userId, string password, string name)
        {
            return  null;
        }

    }
}

