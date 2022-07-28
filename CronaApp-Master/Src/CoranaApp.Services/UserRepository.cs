using CoronaApp.Dal;
using CoronaApp.Dal.models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class UserRepository : IUserRepository
{
    private IConfiguration _configuration;
    IUserDal userdal;
    public UserRepository(IUserDal userdal, IConfiguration configuration)
    {
        this.userdal = userdal;
        this._configuration = configuration;
    }
    public HttpContent getUserName(HttpContent httpContext)
    {
        return httpContext;
        
    }
    public async Task<string> Post(User user)
    {
        if(userdal.LogIn(user)==null)
              await userdal.Post(user);
        return await LogIn(user);
    }
    public async Task<string> LogIn(User user)
    {
        User userFound = await userdal.LogIn(user);
        if (userFound == null)
            return null;
        return CreateToken(userFound);
    }
    public string CreateToken(User user)
    {
        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        
                    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);
        string userToken = new JwtSecurityTokenHandler().WriteToken(token);
        return userToken;
    }


}

