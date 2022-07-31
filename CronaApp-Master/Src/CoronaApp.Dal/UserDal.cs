using CoronaApp.Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class UserDal : IUserDal
{
    CoronaAppContext context;
    public UserDal(CoronaAppContext context)
    {
        this.context = context;
    }

    public async Task AddNewUser(User user)
    {
        try { 
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception("Failed to save changes in db");
        }
    }

    public async Task<User> LogIn(User user)
    {
        // await using (CoronaAppContext context = new CoronaAppContext())
        {
            User userFound;
            try
            {
                userFound = await context.Users.FirstOrDefaultAsync(u =>
                u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password));
            }
            catch (Exception ex)
            {
                throw new Exception("Server error when trying to read data from db");
            };
            return userFound;

        }

    }
}

