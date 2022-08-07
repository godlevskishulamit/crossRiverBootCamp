using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
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
        IPatientService _PatientService;
        public PatientController(IPatientService PatientService)
        {
            _PatientService = PatientService;
        }



        // POST api/<PatientController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Patient newPatient)
        {
            if (newPatient == null)
                return StatusCode(400, "bad request");
            try
            {
                return await _PatientService.addNewPatient(newPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


    }
}
