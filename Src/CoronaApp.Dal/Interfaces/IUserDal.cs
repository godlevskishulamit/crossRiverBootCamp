namespace CoronaApp.Dal.Interfaces
{
    public interface IUserDal
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(User user);
    }
}