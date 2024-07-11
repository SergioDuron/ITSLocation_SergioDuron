using ITSLocation.Application.Interfaces;
using ITSLocation.Domain.Entities;
using ITSLocation.Domain.RepositoryInterfaces;
using log4net;

namespace ITSLocation.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(LocationService));

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Location GetLocationById(int id)
        {
            log.Info($"Fetching location with id {id}");
            return _locationRepository.GetLocationById(id);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            log.Info($"GetAllLocations");
            return _locationRepository.GetAllLocations();
        }

    }
}
