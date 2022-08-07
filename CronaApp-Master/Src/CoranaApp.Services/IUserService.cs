using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IUserService
{
    public Task<UserDTO> login(UserLoginDTO userLogin);
    public Task<UserDTO> signUp(UserLoginDTO userLogin);
    public string getUserNameFromToken(ClaimsPrincipal User);

}
