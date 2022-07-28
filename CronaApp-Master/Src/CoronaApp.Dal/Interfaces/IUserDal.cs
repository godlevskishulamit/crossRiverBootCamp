using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;

namespace CoronaApp.Dal.Interfaces
{
    public interface IUserDal
    {
      Task<User> getUser(int userId, string password, string name);
       Task PostUser(User user);
    }
}

