using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CoronaApp.Services.Functions;

public class UserFunc : IUserRepository
{
    private readonly IConfiguration _configuration;

    public UserFunc(IConfiguration config)
    {
        _configuration = config;
    }

    public async Task<string> CreateToken(string userName, string password)
    {
        using (CoronaContext db = new CoronaContext(_configuration))
        {
            Dal.User user = await db.Users.FirstOrDefaultAsync(u => u.Name == userName && u.Password == password);
            return user != null ? generateJwtToken(user) : throw new UnauthorizedAccessException("UserName or password in incorrect.");
        }
    }

    private string generateJwtToken(Dal.User user)
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

    public async Task PostUser(Dal.User user)
    {
        using(CoronaContext db = new CoronaContext(_configuration))
        {
            if (await db.Users.AnyAsync(u => u.Name == user.Name))
                throw new Exception("User already exists.");

            db.Users.Add(user);
            await db.SaveChangesAsync();
        }
    }

    public async Task<string> getUserName(ClaimsPrincipal user)
    {
        string userName = user.Claims.FirstOrDefault(x=> x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
        return userName ?? throw new UnauthorizedAccessException("Token is incorrect.");
    }
}
