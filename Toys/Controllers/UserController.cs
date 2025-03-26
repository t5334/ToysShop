using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
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

        // POST api/<UserController>
        [HttpPost("register")]
        public ActionResult<User> Post([FromBody]User user)
        {
            string filePath = "M:\\web-api\\user.txt";
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Close();
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Postlogin([FromBody] User user)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:\\web-api\\user.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user1 = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == user1.userName && user.password == user1.password)
                        return Ok(user1);
                }
            }
            return NotFound(new { Message = "User not found." });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
