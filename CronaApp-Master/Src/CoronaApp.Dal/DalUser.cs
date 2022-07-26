using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class DalUser : IDalUser
    {
        public CoronaDbContext context;
        public DalUser(CoronaDbContext context)
        {
            this.context = context;
        }
       public async Task<User> getUser(UserDTO user)
        {
            return context.Users.First(x => x.UserName == user.UserName && x.Password == user.Password);
            
        }

    }
}
