using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Services
{
    public interface IUserRepository
    {
        Task<User> getUser(int userId, string password, string name);
        // Task<IActionResult> signIn([FromBody] User _user);
        Task PostUser(User user);
        Task<string> createToken(string userName, string password);

        Task<string> getUserName(ClaimsPrincipal user);
    }
}

