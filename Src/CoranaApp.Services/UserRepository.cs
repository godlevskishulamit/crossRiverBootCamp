using CoronaApp.Dal;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;
public class UserRepository : IUserRepository
{
    IUserDal _IUserDal;
    IConfiguration _configuration;
    public UserRepository(IUserDal IUserDal, IConfiguration IConfiguration)
    {
        _IUserDal = IUserDal;
        _configuration = IConfiguration;
    }
    public async Task<string> logIn(User newUser)
    {
        User user = await _IUserDal.logIn(newUser);
        if (user != null)
        {
            return await getToken(user);
        }
        else
        {
            return null;
        }
    }

    public async Task<string> signUp(User newUser)
    {
        if (await _IUserDal.logIn(newUser) == null)
        {
            await _IUserDal.signUp(newUser);

            return await logIn(newUser);
        }
        else
        {
            return null;
        }

    }

    public async Task<string> getToken(User user)
    {
        //create claims details based on the user information
        var claims = new[] {
                        new Claim("UserId", user.ID.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Role", "user")
                    };
        var issuer = "https://exemple.com";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
