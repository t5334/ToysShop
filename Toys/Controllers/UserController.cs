using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<UserController>
        [HttpPost("register")]
        public ActionResult<User> Post([FromBody]User user) 
        {
            User user2 = userService.register(user);
            return CreatedAtAction("Get", new { id = user.userId }, user2);
        }

        [HttpPost("login")]
        public ActionResult<User> Postlogin([FromBody] User user)
        {
            User user1 = userService.login(user);
            if (user1 is not null)
            {
                return Ok(user1);
            }
            return NotFound(new { Message = "User not found." });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            User user = userService.updateUser(id, userToUpdate);
            if (user is not null)
            {
                return Ok(user);
            }

            return NotFound(new { Message = "User not found" });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
