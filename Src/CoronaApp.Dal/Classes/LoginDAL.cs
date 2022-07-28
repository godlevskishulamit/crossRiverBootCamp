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
    public class LoginDAL : ILoginDAL
    {
        public async Task<User> GetUser(User user)
        {
            User u;
            using (var _context = new CoronaContext())
            {
                u = await _context.User.FirstOrDefaultAsync(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password));
            }
            return u;
        }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                using (var _context = new CoronaContext())
                {
                    await _context.User.AddAsync(user);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}