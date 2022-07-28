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
        CoronaAppContext _CoronaAppContext;
        public UserDal(CoronaAppContext coronaAppContext)
        {
            _CoronaAppContext = coronaAppContext;
        }
        public async Task<User> logIn(User newUser)
        {
            return await _CoronaAppContext.Users.FirstOrDefaultAsync(user => user.Name == newUser.Name);
        }

        public async Task signUp(User newUser)
        {
            if (logIn(newUser) != null)
            {
                await _CoronaAppContext.Users.AddAsync(newUser);
                await _CoronaAppContext.SaveChangesAsync();
                return;

            }
        }
    }
}
