using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Dal;

public class DalUser : IDalUser
{
    public IConfiguration _configuration;
    public DalUser(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<User> getUser(UserDTO user)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }

    public async Task PostUser(UserDTO user)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            await context.Users.AddAsync(new User() { UserName = user.UserName, Password = user.Password });
            await context.SaveChangesAsync();
        }
    }
}
