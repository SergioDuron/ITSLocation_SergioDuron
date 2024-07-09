using ITSLocation.Application.Interfaces;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace ITSLocation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private static readonly ILog log = LogManager.GetLogger(typeof(LocationController));

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            log.Info($"Fetching location with id {id}");
            var location = _locationService.GetLocationById(id);
            if (location == null)
            {
                log.Warn($"Location with id {id} not found");
                return NotFound();
            }

            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            log.Info("Fetching all locations");
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }
    }
}
