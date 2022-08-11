namespace CoronaApp.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDAL _loginDal;
        private readonly IConfiguration _configuration;
        IMapper mapper;

        public LoginService(ILoginDAL loginDal, IConfiguration configuration)
        {
            _loginDal = loginDal;
            _configuration = configuration;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }
        public async Task<string> Login(UserDTO u)
        {
            User user = await _loginDal.GetUser(mapper.Map<UserDTO,User>(u));
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
                return null;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> SignUp(UserDTO u)
        {
            User user = await _loginDal.GetUser(mapper.Map<UserDTO, User>(u));
            if (user == null)
            {
                bool success = await _loginDal.AddUser(mapper.Map<UserDTO, User>(u));
                if (!success)
                    return "";
                string token = await Login(u);
                return token;
            }
            return ".";
        }

        public string GetUserNameFromToken(ClaimsPrincipal User)
        {
            string userNameClaim=User.Claims.FirstOrDefault(
                            x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
            return userNameClaim;
        }

    }
}
