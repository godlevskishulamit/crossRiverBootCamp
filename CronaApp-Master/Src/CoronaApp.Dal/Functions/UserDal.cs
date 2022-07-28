using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Functions
{
    public class UserDal:IUserDal
    {
        private readonly IConfiguration _configuration;
        public UserDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> getUser(int userId,string password, string name)
        {
            await using (var db = new CoronaContext(_configuration)) 
            {
                return await db.Users.FirstOrDefaultAsync(u => u.UserId.Equals(userId));
            }
           
        }
        public async Task PostUser(User user)
        {
            await using (CoronaContext db = new CoronaContext(_configuration))
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }


    }
}

