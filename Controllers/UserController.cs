using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_rra1.ClassModels;
using api_rra1.ClassModels.Database;
using api_rra1.ClassModels.Database.UserFunctions;

namespace api_rra1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            return ReadUser.ReadAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User value)
        {
            SaveUser.CreateUser(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User value)
        {
            UpdateUser.ChangeUser(id, value);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DeleteUser.DeleteUserr(id);
        }
    }
}
