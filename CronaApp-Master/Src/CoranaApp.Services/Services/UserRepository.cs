
using AutoMapper;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Mappers;

namespace CoronaApp.Services.Services;

public class UserRepository : IUserRepository
{
    public IDalUser _idu;
    public IConfiguration _configuration;
    public IMapper _mapper;

    public UserRepository(IDalUser idu, IConfiguration configuration)
    {
        _idu = idu;
        _configuration = configuration;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
        });
        _mapper = config.CreateMapper();
    }
    public async Task<User> getUser(UserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        return await _idu.getUser(user);
    }
    public string login(User user)
    {
        return createToken(user);
    }
    public async Task<string> signUp(UserDTO userDTO)
    {
        try
        {
           User user =await getUser(userDTO);
            if (user != null)
            {
                return login(user);
            }
            else
            {
                User mapUser = _mapper.Map<User>(userDTO);
                User newUser = await _idu.PostUser(mapUser);
                return createToken(newUser);
            }
        }
        catch(Exception)
        {
            return null;
        }

    }
    public string createToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("userPassword", user.Password),
                new Claim("userName", user.UserName),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
                new Claim(ClaimTypes.Role,"user")
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);


        return tokenHandler.WriteToken(token);
    }
    public async Task<string> GetNameByToken(ClaimsPrincipal user)
    {
        var userName = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userName", StringComparison.InvariantCultureIgnoreCase));
        if (userName != null)
        {
            return userName.ToString();
        }
        else
        {
            return null;
        }
    }
}
