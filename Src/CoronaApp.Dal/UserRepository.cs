using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class UserRepository : IUserRepository
{

    public UserRepository()
    {

    }
    public async Task<User> login(string name, string password)
    {
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            return await _CoronaAppDBContext.Users.Where(user => user.Name.Equals(name) && user.Password .Equals( password)).FirstOrDefaultAsync();
        }
    }
    public async Task<User> signUp(string name, string password)
    {
        User user = new User();
        User existingUser = await login(name, password);
        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            if (existingUser == null)
            {
                /*if (await _CoronaAppDBContext.Users.Where(user => user.Name.Equals(name)).FirstAsync() != null)
                {
                    throw new InvalidOperationException("UserName already exist");
                }*/
                user.Name = name;
                user.Password = password;
            }
            else
                user = existingUser;
            try
            {
                await _CoronaAppDBContext.Users.AddAsync(user);
                await _CoronaAppDBContext.SaveChangesAsync();
                return user;
            }
            catch
            {
                throw new DbUpdateException ();
            }
        }
    }
}
