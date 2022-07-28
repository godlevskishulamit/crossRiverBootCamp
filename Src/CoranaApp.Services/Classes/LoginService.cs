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

namespace CoronaApp.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDAL _loginDal;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginDAL loginDal, IConfiguration configuration)
        {
            _loginDal = loginDal;
            _configuration = configuration;
        }
        public async Task<string> Login(User u)
        {
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            User user = await _loginDal.GetUser(u);
            string token = CreateToken(user);
            return token;
        }
        private string CreateToken(User user)
        {
            JwtSecurityToken token;
            if (user != null)
            {
                var claims = new[] {
                          new Claim("UserId", user.ID.ToString()),
                          new Claim("UserName", user.UserName),
                          new Claim("Role", "user")
                    };

                var issuer = _configuration["JWT:Issuer"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                token = new JwtSecurityToken(
                    issuer,
                    issuer,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

            }
            else
            {
                return null;
            }
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> SignUp(User u)
        {
            if (u == null)
                throw new ArgumentNullException(nameof(u));
            User user = await _loginDal.GetUser(u);
            if (user == null)
            {
                bool success = await _loginDal.AddUser(u);
                if (!success)
                {
                    return "";
                }
            }
            string token = await Login(u);
            return token;
        }

        //public object GetUserNameFromToken(ClaimsIdentity identity)
        //{
        //    string userNameClaim;
        //    //= identity.Claims.Where(x => x.Type == ClaimTypes.).FirstOrDefault().ToString();
        //    if (identity != null)
        //    {
        //        IEnumerable<Claim> claims = identity.Claims;
        //        // or
        //        userNameClaim=identity.Claims.FirstOrDefault(x=>x.Properties.Keys.).Claims.FirstOrDefault("UserName").Value;

        //    }
        //    return userNameClaim;
        //}

    }
}
