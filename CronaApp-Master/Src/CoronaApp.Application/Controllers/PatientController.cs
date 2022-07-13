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
        public Task<List<Patient>> Get()
        {
            return ip.Get();
        }
        [HttpPost]
        public void Add([FromBody] Patient pat)
        {
            ip.postPatient(pat);
        }

    }
}
