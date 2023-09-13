using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShellTodayNews.Models;
using ShellTodayNews.Services.Interface;
using System.Text.Json.Serialization;

namespace ShellTodayNews.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {


        public IUser? _user;

        public UserController(IUser? user) {

            _user = user;
        }


        [HttpPost]
        

        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            return Ok(await _user.CreateUser(user));
        }
        
        [HttpGet]

        public async Task<ActionResult<User>> LoginUser(string username, string password)
        {
            try
            {
                var user = await _user.LoginUser(username, password);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return NotFound("Incorrect Username or password");

            }

 
        }
    }
}
