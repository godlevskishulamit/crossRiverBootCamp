namespace CoronaApp.Services.Classes;

public class UserService : IUserService
{
    public IConfiguration _configuration;
    private readonly IUserDal _userDal;
    IMapper mapper;
    public UserService(IUserDal userDal, IConfiguration configuration)
    {
        _configuration = configuration;
        _userDal = userDal;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
    }

    public async Task<String> GetTokenForUser(UserDTO userData)
    {
        User user = mapper.Map<User>(userData);
        User currentUser = await _userDal.GetUser(user);
        string token = CreateToken(currentUser);
        return token;
    }

    public string CreateToken(User user)
    {
        if (user != null)
        {
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Password", user.Password)
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
        return null;
    }

    public async Task<string> SignUp(UserDTO userDto)
    {

        User user = mapper.Map<User>(userDto);
        User existsUser = await _userDal.GetUser(user);
        if (existsUser != null)
            return null;
        User addedUser = await _userDal.AddUser(user);
        if(addedUser == null)
            return null;
        string token = await GetTokenForUser(userDto);
        return token;
    }
}
