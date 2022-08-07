using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        // GET: api/<LoginController>

        // GET api/<LoginController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<LoginController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> login([FromBody] UserLoginDTO userLogin)
        {
            if (userLogin == null)
                return StatusCode(400, "bad request");
            try
            {
                UserDTO user = await _UserService.login(userLogin);

                if (user == null)
                {
                    return StatusCode(204, "no such user");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // POST api/<LoginController>
        [HttpPost("signUp")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> signUp([FromBody] UserLoginDTO newUser)
        {

            if (newUser == null)
                return StatusCode(400, "bad request");
            try
            {
                UserDTO user = await _UserService.signUp(newUser);

                if (user == null)
                {
                    return StatusCode(204, "no such user");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getUserName")]
        public ActionResult<string> getUserNameFromToken()
        {
            try
            {
                string userName = _UserService.getUserNameFromToken(User);
                if (userName == null)
                {
                    return StatusCode(204, "no such user");
                }
                return Ok(userName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
