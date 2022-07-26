using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<User> getUser(int userId, string password, string name);

    }
}

