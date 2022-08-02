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

    public UserDal()
    {
        
    }

    public async Task<User> CreateToken(string userName, string password)
    {
        User user;
        using (CoronaContext context = new CoronaContext())
        {
             user = context.Users.FirstOrDefault(u => u.Name == userName && u.Password == password);       
        }
        if (user == null)
        {
            return null;
        }
        else
        {
            return user;
        }
    }

    public async Task PostUser(User user)
    {
        
        using (CoronaContext context = new CoronaContext())
        {
            context.Users.Add(user);
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Failed to save changes");
            }
        }
    }

}

