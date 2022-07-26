using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _UserRepositoty;
        public UserController(IUserRepository UserRepositoty)
        {
            _UserRepositoty = UserRepositoty;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<UserDTO> login([FromBody] UserLoginDTO userLogin)
        {
            return await _UserRepositoty.login(userLogin);
        }
        // POST api/<LoginController>
        [HttpPost("signUp")]
        [AllowAnonymous]
        public async Task<UserDTO> signUp([FromBody] UserLoginDTO newUser)
        {
            return await _UserRepositoty.signUp(newUser);
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
