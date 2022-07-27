using CoronaApp.Dal;
using CoronaApp.Dal.Models;
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

namespace CoronaApp.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _configuration;


        public UserRepository(IUserDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration; 
        }

        /*public async Task<string> CreateToken(string userName, string password)
        {
            User user = await _userDal.CreateToken(userName, password);
            if (user == null)
            {
                return null;
            }
            else
            {
                return generateJwtToken(user);
            }
        }*/

        private string generateJwtToken(User user)
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

        public async Task PostUser(User user)
        {
            await _userDal.PostUser(user);
        }
    }
}
