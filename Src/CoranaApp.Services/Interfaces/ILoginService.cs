namespace CoronaApp.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(UserDTO u);
        Task<string> SignUp(UserDTO u);
        string GetUserNameFromToken(ClaimsPrincipal token);
    }
}