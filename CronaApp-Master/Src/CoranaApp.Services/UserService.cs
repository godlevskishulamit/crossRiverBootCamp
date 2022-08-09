using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoronaApp.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        private IConfiguration _config;
        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }
        public async Task<UserDTO> Login(UserLoginDTO userLogin)
        {
            if (userLogin != null)
            {
                var user = await _userRepository.Login(userLogin.Name, userLogin.Password);
                if (user != null)
                {
                    UserDTO userDto = new();
                    userDto.Token = await generateJsonWebToken(user);
                    userDto.Name = user.Name;
                    userDto.Id = user.Id;
                    return userDto;
                }
                else       //user not exist in database
                    throw new Exception("user not exist");
            }
            return null;


        }

        public async Task<UserDTO> SignUp(UserLoginDTO userLogin)
        {
            if (userLogin != null)
            {
                var user = await _userRepository.SignUp(userLogin.Name, userLogin.Password);
                UserDTO userDTO=new();
                userDTO.Id = user.Id;
                userDTO.Name = user.Name;
                userDTO.Token = await generateJsonWebToken(user);
                return userDTO;
            }
            return null;
        }
        public async Task<string> generateJsonWebToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWT:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new ("UserId", user.Password.ToString()),
                    new("UserName", user.Name),
                    new("Role", "user")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
