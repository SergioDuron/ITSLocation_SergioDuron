using ITSLocation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSLocation.Domain.RepositoryInterfaces
{
    public interface ILocationRepository
    {
        Location GetLocationById(int id);
        IEnumerable<Location> GetAllLocations();
    }
}
