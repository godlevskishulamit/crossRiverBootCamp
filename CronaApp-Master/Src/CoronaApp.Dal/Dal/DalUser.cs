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
    public async Task<User> getUser(User user)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));
        }
    }

    public async Task<User> PostUser(User user)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
