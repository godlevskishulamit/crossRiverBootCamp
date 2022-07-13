using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientRepository PatientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            this.PatientRepository = patientRepository;
        }
        [HttpGet]
        public async Task<ICollection<Patient>> GetAllUsers()
        {
            return await this.PatientRepository.GetAllPatient();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public object Get(string id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            await this.PatientRepository.PostPatient(patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut/*("{id}")*/]
        public async Task Put([FromBody] Patient patient)
        {
            await this.PatientRepository.UpdatePatient(patient);
        }

     
    }
}
