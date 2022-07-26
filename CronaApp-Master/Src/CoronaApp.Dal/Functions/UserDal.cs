using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal.Functions
{
    public class UserDal:IUserDal
    {
        CoronaContext _db;
        public UserDal(CoronaContext db)
        {
            _db = db;
        }

        public async Task<User> getUser(int userId,string password, string name)
        {

            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }


    }
}

