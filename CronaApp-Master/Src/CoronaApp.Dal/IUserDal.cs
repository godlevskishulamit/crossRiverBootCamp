using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IUserDal
{
    public Task<User> login(string name, string password);
    public Task<User> signUp(string name, string password);

}
