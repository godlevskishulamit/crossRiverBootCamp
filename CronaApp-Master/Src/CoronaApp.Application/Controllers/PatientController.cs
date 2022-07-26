using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
            if (listPat == null)
            {
                return StatusCode(404, "not found");
            }
            if (!listPat.Any())
            {
                return StatusCode(204, "no content");
            }
            return Ok(listPat);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    public async Task Add([FromBody] Patient pat)
    {
        try
        {
           await ip.postPatient(pat);
        }
        catch(Exception ex)
        {
            StatusCode(500, ex.Message);
        }
        
    }

}
