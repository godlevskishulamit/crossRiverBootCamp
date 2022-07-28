using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class UserDal : IUserDal
    {
        public async Task<User> logIn(User newUser)
        {
            try
            {
                using (var _CoronaAppDBContext = new CoronaAppDBContext())
                {
                    return await _CoronaAppDBContext.Users.FirstOrDefaultAsync(user => user.Name == newUser.Name);
                }
            }
            catch (Exception)
            {
                throw new Exception("internal error with SaveChangesAsync function");
            }
        }
        public async Task signUp(User newUser)
        {
            try
            {
                using (var _CoronaAppDBContext = new CoronaAppDBContext())
                {
                    await _CoronaAppDBContext.Users.AddAsync(newUser);
                    await _CoronaAppDBContext.SaveChangesAsync();
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception("internal error with SaveChangesAsync function");
            }
            
        }
    }
}
