﻿namespace CoronaApp.Services.Interfaces;

public interface IUserService
{
    string CreateToken(User user);
    Task<string> GetTokenForUser(UserDTO userData);
    Task<string> SignUp(UserDTO user);
}