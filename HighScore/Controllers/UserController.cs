using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighScore.DAO;
using HighScore.Model;
using Microsoft.AspNetCore.Mvc;

namespace HighScore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserDatabase.GetUserList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return UserDatabase.GetUser(id);
        }

        // POST api/user/
        [HttpPost]
        public JsonResult Add([FromForm] string name, [FromForm] string country)
        {
            int id = UserDatabase.AddUser(new User { Name = name, Country = country });
            return Json(new { Id = id });
        }

        // DELETE api/user/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserDatabase.RemoveUser(id);
        }
    }
}
