using Microsoft.EntityFrameworkCore;
using ShellTodayNews.Models;
using ShellTodayNews.Services.Interface;

namespace ShellTodayNews.Services
{
    public class UserService : IUser

    {
        private ShellTodayNewsDbContext? _context;

        public UserService(ShellTodayNewsDbContext? context)
        {
            _context = context;
        }



      

		public async Task<List<User>> CreateUser(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return await _context.Users.ToListAsync();
		}

		public async Task<User> LoginUser(string email, string password)
		{ 
			var user=await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email)&& u.Password.Equals(password));
			if (user != null) 
			{
				return user;
			}
			else
			{
				throw new Exception();
			}
			
		} 
    }
}
