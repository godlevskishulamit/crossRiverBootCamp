using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoronaApp.Services
{
    public class UserRepository : IUserRepository
    {
        IUserDal _dal;
        private readonly IConfiguration _configuration;
        public UserRepository(IUserDal dal, IConfiguration configuration)
        {
            _dal = dal;
            _configuration = configuration;
        }

        public Task<User> getUser(int userId, string password, string name)
        {
            return _dal.getUser(userId, password, name);
        }

        public async Task<string> createToken(string userName,string password)
        {
           await using (CoronaContext db = new CoronaContext(_configuration))
            {
                User user = db.Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password == password);
                return user != null ? generateJwtToken(user) : null;
            }
        }
        private string generateJwtToken(User user)
        {
            var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("Password", user.Password),
                        new Claim("Name", user.UserName)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task PostUser(User user)
        {
           _dal.PostUser(user);
        }

        public async Task<string> getUserName(ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
        }
    }
}

