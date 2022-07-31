using CoronaApp.Dal.models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles =  "user")]

public class UserController : ControllerBase
{
    IUserRepository userRepository;
    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    

    // GET api/<LogInController>/5
    [HttpGet("userName")]
    public ActionResult<string> GetUserName()
    {
        var userName = userRepository.GetUserName(User);
        if (userName == null)
            return StatusCode(404, "not found");
        if (!userName.Any())
            return StatusCode(204, "no content");
        return Ok(userName);
    }
    [AllowAnonymous]
    [HttpPost("signUp")]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        var token = await userRepository.AddNewUser(user);
        if (token == null)
            return StatusCode(404, "not found");
        if(!token.Any())
            return StatusCode(204, "no content");
        return Ok(token);
    }
    // POST api/<LogInController>
    [AllowAnonymous]
    [HttpPost("signIn")]
    public async Task<IActionResult> PostLogIn([FromBody] User user)
    {
        var token = await userRepository.LogIn(user);
        if (token == null)
            return StatusCode(404, "not found");
        if (!token.Any())
            return StatusCode(204, "no content");
        return Ok(token);
    }

    
}

