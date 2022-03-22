using Microsoft.AspNetCore.Mvc;
using PasswordHash_BCript.Data;
using PasswordHash_BCript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordHash_BCript.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        public UserController(UserContext context)
        {
            _userContext = context;
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            User user = new User() { Login = userDto.Login, Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password) };
            _userContext.Add(user);
            _userContext.SaveChanges();
            return CreatedAtAction("AddUser", user);
        }

        [HttpGet]
        [Route("getUsers")]
        public ActionResult<IEnumerable<User>> getUsers()
        {
            return Ok(_userContext.Users);
        }

        [HttpPost]
        [Route("authUser")]
        public ActionResult AuthenticateUser([FromBody] UserDto userDto)
        {
            //First we check if there is any login like this on the database
            if (!_userContext.Users.Any(x => x.Login == userDto.Login)) return BadRequest("Invalid Credentials");
       
            //Then we get the user from the database
            var user = _userContext.Users.FirstOrDefault(user => user.Login == userDto.Login);
       
            //Now we check if the user on the database has a valid hash according to the userDto password
            if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password)) return BadRequest("Invalid Credentials");
       
            return Ok("Valid Credentials!");
       
        }
    }
}


