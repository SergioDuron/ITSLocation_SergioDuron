using ITSLocation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITSLocation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationController> _logger;


        public LocationController(ILocationService locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            _logger.LogInformation("GetLocationById called with id: {Id}", id);
            var location = _locationService.GetLocationById(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            _logger.LogInformation("GetAllLocations called");
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }
    }
}
