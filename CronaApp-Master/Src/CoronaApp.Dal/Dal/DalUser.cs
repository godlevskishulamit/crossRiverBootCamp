using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Dal;

public class DalUser : IDalUser
{
    public CoronaDbContext context;
    public DalUser(CoronaDbContext context)
    {
        this.context = context;
    }
    public async Task<User> getUser(UserDTO user)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);

    }

    public async Task PostUser(UserDTO user)
    {
        await context.Users.AddAsync(new User() { UserName = user.UserName, Password = user.Password });
        await context.SaveChangesAsync();
    }
}
