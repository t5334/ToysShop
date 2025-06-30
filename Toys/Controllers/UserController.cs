using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Entities;
using System.Threading.Tasks;
using DTO;

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
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST api/<UserController>
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Post([FromBody]User user) 
        {
            UserDTO user2 = await userService.register(user);
            if (user2 is not null)
                return Ok(user2);
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Postlogin([FromBody] User user)
        {
            UserDTO user1 =await userService.login(user);
            if (user1 is not null)
            {
                return Ok(user1);
            }
            return NotFound(new { Message = "User not found." });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserDTO userToUpdate)
        {
            UserDTO user = await userService.updateUser(id, userToUpdate);
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
