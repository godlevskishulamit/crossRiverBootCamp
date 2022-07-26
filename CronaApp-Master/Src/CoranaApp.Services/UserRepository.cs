using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;

namespace CoronaApp.Services
{
    public class UserRepository:IUserRepository
    {
        IUserDal _dal;
        public UserRepository(IUserDal dal)
        {
            _dal = dal;
        }

        public Task<User> getUser(int userId, string password, string name)
        {
            return _dal.getUser(userId, password, name);
        }
    }
}

