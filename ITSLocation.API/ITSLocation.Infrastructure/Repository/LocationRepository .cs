using ITSLocation.Domain.Entities;
using ITSLocation.Domain.RepositoryInterfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSLocation.Infrastructure.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Location> _locations;
        private static readonly ILog log = LogManager.GetLogger(typeof(LocationRepository));

        public LocationRepository()
        {
            // Datos en código duro
            _locations = new List<Location>
            {
                new Location { Id = 1, Name = "Location 1", Description = "Description for Location 1" },
                new Location { Id = 2, Name = "Location 2", Description = "Description for Location 2" },
                new Location { Id = 3, Name = "Location 3", Description = "Description for Location 3" }
            };
        }

        public Location GetLocationById(int id)
        {
            log.Info("GetLocationById");
            return _locations.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            log.Info("GetAllLocations");
            return _locations;
        }
    }
}
