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

public class UserService : IUserService
{
    IUserRepository _userRepository;
    IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;

    }
    public async Task<UserDTO> login(UserLoginDTO userLogin)
    {
        if (userLogin != null)

        {
            User user = await _userRepository.login(userLogin.Name, userLogin.Password);
            if (user == null)
                return null;
            UserDTO userDto = new UserDTO();
            string token = await getToken(user);
            userDto.Token = token;
            userDto.Name = user.Name;
            userDto.Id = user.Id;
            return userDto;
        }
        return null;
    }

    public async Task<UserDTO> signUp(UserLoginDTO newUser)
    {
        if (newUser != null)
        {
            User user = await _userRepository.signUp(newUser.Name, newUser.Password);

            UserDTO _newUser = new UserDTO();
            _newUser.Name = user.Name;
            _newUser.Id = user.Id;
            _newUser.Token = await getToken(user);
            return _newUser;
        }
        return null;
    }
    public async Task<string> getToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
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
        return tokenHandler.WriteToken(token);
    }
}
