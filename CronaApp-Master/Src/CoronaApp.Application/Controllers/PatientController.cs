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

        IPatientRepository ip;
        public PatientController(IPatientRepository ip)
        {
            this.ip = ip;
        }
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            try
            {
                List<Patient> listPat = await ip.Get();
                if (listPat != null)
                {
                    return Ok(listPat);
                }
                return StatusCode(404, "not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public void Add([FromBody] Patient pat)
        {
            try
            {
                ip.postPatient(pat);
            }
            catch(Exception ex)
            {
                StatusCode(500, ex.Message);
            }
            
        }

    }
}
