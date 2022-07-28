using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
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
        IPatientRepository _repo;
        public PatientController(IPatientRepository repo)
        {
            _repo = repo;
        }


        // GET api/<PatientController>/5
        [HttpGet("id")]
        public async Task<Patient> GetAsync()
        {
            return await _repo.GetAsync(User);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<bool> SaveAsync([FromBody] Patient patient)
        {
            try
            {
                await _repo.SaveAsync(patient);
                return true;
            }
            catch
            {
                throw new("Server Err: Couldn't save data.");
            }
    
        }
       

       

     
    }
}
