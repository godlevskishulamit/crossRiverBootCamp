using CoronaApp.Dal.DTO;
using CoronaApp.Services;
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
    }
    [HttpPost]
    public  ActionResult<string> login([FromBody] UserDTO userDTO)
    {
       var user= iur.getUser(userDTO).Result;
        //generate token
        if(user == null)
        {
            return NotFound();
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(user.Password, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);


        return Ok(tokenHandler.WriteToken(token));

    }



}
