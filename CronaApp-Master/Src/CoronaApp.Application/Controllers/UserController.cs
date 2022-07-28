using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Functions;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private IConfiguration _configuration;


        public UserController(IUserRepository repo,IConfiguration configuration)
        {
            _repo = repo;
            _configuration=configuration;
        }

        [HttpPost("signIn")]
        public async Task signIn([FromBody]User user)
        {
            await _repo.PostUser(user);
        }

        [HttpPost("Token")]
        public async Task<IActionResult> createToken(string userName, string password)
        {
            var token = await _repo.createToken(userName, password);
            return token!=null ? Ok(token) : BadRequest(new {message="UserName or password is incorrect"}); 
        }


        [HttpGet]
        public async Task<User> GetUser(int userId, string password, string name)
        {
            return await _repo.getUser(userId,password,name);
        }

        [HttpGet("getUserName")]
        public async Task<string> getUserName(ClaimsPrincipal user)
        {
            return await _repo.getUserName(user);
        }

    }
}

