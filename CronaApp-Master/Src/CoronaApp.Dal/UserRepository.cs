using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public class UserRepository : IUserRepository
{

    public async Task<User> Login(string name, string password)
    {
        using (var _dbContext = new CoronaDBContext())
        {
            return await _dbContext.Users.Where(user => user.Name.Equals(name) && user.Password.Equals(password)).SingleOrDefaultAsync();
        }

    }
    public async Task<User> SignUp(string name, string password)
    {
        User user = await Login(name, password);
        if (user != null)
        {
            return user;
        }
        else
        {
            using (var _dbContext = new CoronaDBContext())
            {
                if (await _dbContext.Users.Where(user => user.Name.Equals(name)).FirstOrDefaultAsync() != null)
                    throw new Exception("User Name Already Exists");
                if (await _dbContext.Users.Where(user => user.Password.Equals(password)).FirstOrDefaultAsync() != null)
                    throw new Exception("User Password Already Exists");
                user = new User { Name = name, Password = password };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
        
        }
    }
}

