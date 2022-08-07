using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
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
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;

    }
    public async Task<UserDTO> login(UserLoginDTO userLogin)
    {
        if (userLogin != null)

        {
            User user = await _userRepository.login(userLogin.Name, userLogin.Password);
            if (user == null)
                return null;
            UserDTO userDto = _mapper.Map<UserDTO>(user);
            userDto.Token = await getToken(user);
            return userDto;
        }
        return null;
    }

    public async Task<UserDTO> signUp(UserLoginDTO newUser)
    {
        if (newUser != null)
        {
            User user = await _userRepository.signUp(newUser.Name, newUser.Password);

            UserDTO _newUser= _mapper.Map<UserDTO>(user);
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

    public string getUserNameFromToken(ClaimsPrincipal User)
    {
        string userName=User.Claims.FirstOrDefault(
                        x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
        return userName;
   
    }

}
