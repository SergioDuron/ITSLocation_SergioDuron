using ITSLocation.Application.Interfaces;
using ITSLocation.Domain.Entities;
using ITSLocation.Domain.RepositoryInterfaces;

namespace ITSLocation.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Location GetLocationById(int id)
        {
            return _locationRepository.GetLocationById(id);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _locationRepository.GetAllLocations();
        }
    }
}
