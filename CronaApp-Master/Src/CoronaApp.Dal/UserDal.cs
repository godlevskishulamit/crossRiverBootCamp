using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class UserDal : IUserDal
{
    CoronaAppDBContext _CoronaAppDBContext;
    public UserDal(CoronaAppDBContext CoronaAppDBContext)
    {
        _CoronaAppDBContext = CoronaAppDBContext;
    }
    public async Task<User> login(string name, string password)
    {
        return await _CoronaAppDBContext.Users.Where(user => user.Name == name && user.Password == password).FirstOrDefaultAsync();

    }

    public async Task<User> signUp(string name, string password)
    {
        User user = new User();
       User existingUser = await login(name,password);
        if (existingUser == null)
        {
            user.Name = name;
            user.Password = password;
        }
        else
            user = existingUser;
        await _CoronaAppDBContext.Users.AddAsync(user);
        await _CoronaAppDBContext.SaveChangesAsync();
        return user;
    }
}