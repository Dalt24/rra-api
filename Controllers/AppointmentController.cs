using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rra1.ClassModels;
using api_rra1.ClassModels.Database;
using api_rra1.ClassModels.Database.AppointmentFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_rra1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        // GET: api/Appointment
        [HttpGet]
        public List<Appointment> Get()
        {
            return ReadAppointment.ReadAllAppointments();
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Appointment
        [HttpPost]
        public void Post([FromBody] Appointment value)
        {
            SaveAppointment.CreateAppointment(value);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Appointment value)
        {
            UpdateAppointment.ChangeAppointment(id, value);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
