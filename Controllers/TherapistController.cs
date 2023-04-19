using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rra1.ClassModels;
using api_rra1.ClassModels.Database.TherapistFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_rra1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapistController : ControllerBase
    {
        // GET: api/Therapist
        [HttpGet]
        public List<Therapist> Get()
        {
            return ReadTherapist.ReadAllTherapists();
        }

        // GET: api/Therapist/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Therapist
        [HttpPost]
        public void Post([FromBody] Therapist value)
        {
            SaveTherapist.CreateTherapist(value);
        }

        // PUT: api/Therapist/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Therapist value)
        {
            UpdateTherapist.ChangeTherapist(id, value);
        }

        // DELETE: api/Therapist/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DeleteTherapist.DeleteUserr(id);
        }
    }
}
