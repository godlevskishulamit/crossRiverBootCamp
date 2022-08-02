using CoronaApp.Dal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using AutoMapper;

namespace CoronaApp.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;



        public UserRepository(IUserDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public async Task<string> CreateToken(UserDTO userDTO)
        {
            User userFromDTO = _mapper.Map<UserDTO, User>(userDTO);
            User user = await _userDal.CreateToken(userFromDTO.Name, userFromDTO.Password);
            if (user == null)
            {
                return null;
            }
            else
            {
                return generateJwtToken(user);
            }
        }

        private string generateJwtToken(User user)
        {
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.Name),
                    new Claim("Role", "user"),

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

        public async Task PostUser(UserDTO user)
        {
            User userFromDTO = _mapper.Map<UserDTO, User>(user);
            await _userDal.PostUser(userFromDTO);
        }

        public string GetUserName(ClaimsPrincipal user)
        {
           return user.Claims.FirstOrDefault(
                x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
        }
    }
}
