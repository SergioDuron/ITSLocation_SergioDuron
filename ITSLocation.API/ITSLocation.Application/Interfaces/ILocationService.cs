using ITSLocation.Domain.Entities;

namespace ITSLocation.Application.Interfaces
{
    public interface ILocationService
    {
        Location GetLocationById(int id);
        IEnumerable<Location> GetAllLocations();
    }
}
