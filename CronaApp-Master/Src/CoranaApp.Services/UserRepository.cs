using CoronaApp.Dal;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class UserRepository: IUserRepository
    {
        public IDalUser idu;
        public UserRepository(IDalUser idu)
        {
            this.idu = idu;
        }
        public Task<User> getUser(UserDTO userDTO)
        {
            return idu.getUser(userDTO);
        }
    }
}
