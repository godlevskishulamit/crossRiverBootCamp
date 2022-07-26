using System;
using System.Collections.Generic;
using System.Text;
using CoronaApp.Dal.Interfaces;

namespace CoronaApp.Services
{
    public class UserRepository:IUserRepository
    {
        IUserDal _dal;
        public UserRepository()
        {
        }
    }
}

