using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatientRepository patientrepository;
        public PatientController(IPatientRepository patientrepository)
        {
            this.patientrepository = patientrepository;
        }
        // GET api/<PatientController>/5
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Patient> patients = await patientrepository.Get();
            if (patients != null)
                return Ok(patients);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Patient patient = await patientrepository.GetById(id);
            if (patient != null)
                return Ok(patient);
            return NoContent();
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            await patientrepository.Post(patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task Put( [FromBody] Patient patient)
        {
            await patientrepository.Put(patient);
        }

     
    }
}
