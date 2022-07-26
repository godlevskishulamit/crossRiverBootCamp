using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace CoronaApp.Services;

public class UserRepository : IUserRepository
{
    IUserDal _UserDal;
    IConfiguration _configuration;
    public UserRepository(IUserDal UserDal, IConfiguration configuration)
    {
        _UserDal = UserDal;
        _configuration = configuration;
    }
    public async Task<UserDTO> login(UserLoginDTO userLogin)
    {
        User user = await _UserDal.login(userLogin.Name, userLogin.Password);
        if (user == null)
            return null;
        UserDTO userDto = new UserDTO();
        string token =await getToken(user);
        userDto.Token = token;
        userDto.Name = user.Name;
        userDto.Id = user.Id;
        return userDto;
    }

    public async Task<UserDTO> signUp(UserLoginDTO newUser)
    {
        User user = await _UserDal.login(newUser.Name, newUser.Password);
        if (user == null)
        {
           user = await _UserDal.signUp(newUser.Name, newUser.Password);
        }
        /*
        UserLoginDTO userLogin = new UserLoginDTO();
        userLogin.Name = newUser.Name;
        userLogin.Password = newUser.Password;*/
        UserDTO _newUser = new UserDTO();
        _newUser.Name = user.Name;
        _newUser.Id = user.Id;
        _newUser.Token = await getToken(user);
        return _newUser;
    }
    public async Task<string > getToken(User user)
    {
        /*var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Role","user")
        }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token.ToString();*/
        var claims = new[] {
                        new Claim("UserId", user.Id.ToString()),
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
