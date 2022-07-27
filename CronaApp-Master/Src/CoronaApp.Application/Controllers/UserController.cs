using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
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
    public  ActionResult<string> login([FromBody] UserDTO userDTO)
    {
       var user= iur.getUser(userDTO).Result;
        //generate token
        if(user == null)
        {
            return NotFound();
        }

       return iur.createToken(user);

    }

  
    // [Authorize]
    //[HttpPost]
    //public async Task<ActionResult<string>> PostUser([FromBody]UserDTO user)
    //{
    //    if (user!=null&&user.UserName.Length>0&&user.Password.Length>0)
    //    { 
    //        await iur.PostUser(user);
    //        return iur.createToken(user);
    //    }
    //    else
    //    {
    //        return BadRequest();
    //    }
    //}


}
