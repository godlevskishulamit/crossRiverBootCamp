using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Classes
{
    public class UserDal : IUserDal
    {
        public UserDal()
        {

        }

        public async Task<User> GetUser(User user)
        {
            using (CoronaContext context = new CoronaContext())
            {
                return await context.User.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            }
        }

        public async Task<User> AddUser(User user)
        {
            //User user = new User() { UserName = name, Password = pass };
            try
            {
                using (CoronaContext context = new CoronaContext())
                {
                    await context.User.AddAsync(user);
                    await context.SaveChangesAsync();
                    return user;
                }

            }
            catch
            {
                return null;
            }

        }
    }
}
