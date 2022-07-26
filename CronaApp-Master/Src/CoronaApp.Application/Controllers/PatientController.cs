using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientRepository _PatientRepository;
        public PatientController(IPatientRepository PatientRepository)
        {
            _PatientRepository = PatientRepository;
        }


       
        // POST api/<PatientController>
        [HttpPost]
        public async Task<string> Post([FromBody] Patient newPatient)
        {
            return await _PatientRepository.addNewPatient(newPatient);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

     
    }
}
