using ShellTodayNews.Models;
namespace ShellTodayNews.Services.Interface
{
    public interface IUser
    {
        Task<List<User>> CreateUser(User user);

        Task<User> LoginUser(string email, string password);
    }
}
