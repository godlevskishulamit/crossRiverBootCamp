using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface IUserDal
    {
      
        Task<User> CreateToken(string userName, string password);
        Task PostUser(User user);
        
    }
}
