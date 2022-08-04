using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IUserRepository
{
    Task<User> Login(string name, string password);
    Task<User> SignUp(string username, string password);
}

