
namespace CoronaApp.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    public LocationController(ILocationService locationDal,IMapper mapper)
    {
        _locationService = locationDal;
    }

    // GET: api/<LocationController>/GetAllLocations
    [HttpGet]
    [Route("GetAllLocations")]
    public async Task<IActionResult> GetAllLocations()
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetAllLocations();
            if (locations?.ToArray().Length==0)
                return NoContent();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetAllLocationsByCity/Bnei Brak
    [HttpGet]
    [Route("GetAllLocationsByCity/{city}")]
    public async Task<IActionResult> GetAllLocationsByCity(string city)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocationsByCity(city);
            if (locations?.ToArray().Length == 0)
                return NoContent();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetLocationsByLocationSearch
    [HttpGet]
    [Route("GetLocationsByLocationSearch")]
    public async Task<IActionResult> GetLocationsByLocationSearch([FromBody] LocationSearch locationSearch)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocationsByLocationSearch(locationSearch);
            if (locations?.ToArray().Length == 0)
                return NoContent();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetLocationsPerPatient/123456789
    [HttpGet]
    [Route("GetLocationsPerPatient/{id}")]
    public async Task<IActionResult> GetLocationsPerPatient(string id)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocationsPerPatient(id);
            if (locations?.ToArray().Length == 0)
                return NoContent();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST: api/<LocationController>/AddLocation
    [HttpPost]
    [Route("AddLocation")]
    public async Task<ActionResult<bool>> AddLocation([FromBody] AddLocationDTO locationDto)
    {
        try
        {
            bool res = await _locationService.AddLocation(locationDto);
            if (res)
                return Ok(true);
                //return Ok("The location has been successfully added"
            return BadRequest(false);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // DELETE: api/<LocationController>/123456789
    [HttpDelete]
    [Route("DeleteLocation")]
    public async Task<ActionResult<bool>> DeleteLocation([FromBody] LocationDTO locationDto)
    {
        try
        {
            bool res = await _locationService.DeleteLocation(locationDto);
            if (res)
                return Ok(res);
            return BadRequest(res);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
