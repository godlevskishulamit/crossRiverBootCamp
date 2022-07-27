using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class UserDal : IUserDal
{
    private readonly CoronaContext _context;

    public UserDal(CoronaContext coronaContext)
    {
        _context = coronaContext;
    }

    public async Task<string> CreateToken(string userName, string password)
    {           
        User user  =  _context.Users.FirstOrDefault(u=>u.Name==userName && u.Password == password);
      /*  if(user == null)
        {
            return null;
        }
        else 
        {
            return generateJwtToken(user);
        }*/
    }

    public async Task PostUser(User user)
    {
        _context.Users.Add(user);   
        await _context.SaveChangesAsync();
    }


public string getUserName()
{
        var userName = ClaimTypes.Name;

        //var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        //var email = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
        //var email = _httpContext.User.Claims.FirstOrDefault(c => c.Type == "sub").Value
        //string userName = User.FindFirstValue(ClaimTypes.Name);
        // parse the token.
        
        
        return userName.ToString();
 }

}