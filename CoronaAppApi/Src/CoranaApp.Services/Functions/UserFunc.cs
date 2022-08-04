//using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Services.Functions;

public class UserFunc : IUserRepository
{
    private readonly IConfiguration _configuration;

    public UserFunc(IConfiguration config)
    {
        _configuration = config;
    }

    public async Task<string> CreateToken(string userName, string password)
    {
        await using (CoronaContext db = new CoronaContext(_configuration))
        {
            Dal.User user = db.Users.FirstOrDefault(u => u.Name == userName && u.Password == password);
            return user != null ? generateJwtToken(user) : null;
        }
    }

    private string generateJwtToken(Dal.User user)
    {
        var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.Name),

                };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task PostUser(Dal.User user)
    {
        await using(CoronaContext db = new CoronaContext(_configuration))
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }
    }

    public async Task<string> getUserName(ClaimsPrincipal  user)
    {
        return user.Claims.FirstOrDefault(x=> x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
    }
}
