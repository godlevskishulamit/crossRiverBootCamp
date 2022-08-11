namespace CoronaApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    public LocationController(ILocationService locationDal)
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
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/<LocationController>/GetAllLocationsByCity/Jerusalem
    [HttpGet]
    [Route("GetAllLocationsByCity/{city}")]
    public async Task<IActionResult> GetAllLocationsByCity(string city)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetAllLocations(city);
            return locations==null ? BadRequest("failed! try again later...") : 
                locations.ToArray().Length == 0 ? NoContent(): Ok(locations);
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
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
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
            return locations == null ? BadRequest("failed! try again later...") :
                locations.ToArray().Length == 0 ? NoContent() : Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST: api/<LocationController>/AddLocation
    [HttpPost]
    [Route("AddLocation")]
    public async Task<IActionResult> AddLocation([FromBody] LocationDTO location)
    {
        try
        {
            bool success = await _locationService.AddLocation(location);
            return !success ? BadRequest("Adding location failed! try again later...") : Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // DELETE: api/<LocationController>/123456789
    [HttpDelete]
    [Route("DeleteLocation/{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        try
        {
            bool success = await _locationService.DeleteLocation(id);
            return !success ? BadRequest("Deleting location failed! try again later...") : Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}