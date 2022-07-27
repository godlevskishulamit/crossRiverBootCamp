using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Services
{
    public class UserRepository : IUserRepository
    {
        public IDalUser idu;
        public IConfiguration _configuration;

        public UserRepository(IDalUser idu, IConfiguration _configuration)
        {
            this.idu = idu;
            this._configuration = _configuration;
        }
        public Task<User> getUser(UserDTO userDTO)
        {
            return idu.getUser(userDTO);
        }

        public async Task PostUser(UserDTO user)
        {
            await idu.PostUser(user);
        }
        public string createToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(user.Password, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                    new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}
