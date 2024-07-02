using ITSLocation.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITSLocation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            var location = _locationService.GetLocationById(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }
    }
}
