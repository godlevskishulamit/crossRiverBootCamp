using CoronaApp.Dal.models;
using Microsoft.EntityFrameworkCore;
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

    public async Task Post(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<User> LogIn(User user)
    {
        // await using (CoronaAppContext context = new CoronaAppContext())
        {
            User userFound = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password));
            return userFound;

        }

    }
}

