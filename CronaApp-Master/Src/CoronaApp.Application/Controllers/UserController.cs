using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    IUserRepository iur;
    IConfiguration _configuration;

    public UserController(IUserRepository iur, IConfiguration _configuration)
    {
        this.iur = iur;
        this._configuration = _configuration;
    }
    [HttpPost("login")]
    public async Task<ActionResult<string>> login([FromBody] UserDTO userDTO)
    {
        try
        {
            var user = await iur.getUser(userDTO);
            if (user == null)
            {
                return StatusCode(404);
            }
            try
            {
                string token = iur.login(user);
                if (token == null)
                {
                    return StatusCode(404);
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }

    [Authorize]
    [HttpPost("signup")]
    public async Task<ActionResult<string>> signUp([FromBody] UserDTO user)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, ModelState);
        }
        try
        {
            //how to return the token of the existing user?
            string token = await iur.signUp(user);
            if (token == null)
            {
                return StatusCode(404);
            }
            return Ok(token);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [Authorize]
    [HttpGet("name")]
    public async Task<ActionResult<string>> GetNameByToken()
    {

        var result = await iur.GetNameByToken(User);

        if (result == null)
        {
            return StatusCode(404);
        }
        return Ok(result);
    }

}
