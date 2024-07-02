using NUnit.Framework;
using ITSLocation.Domain.Entities;
using ITSLocation.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ITSLocation.Infrastructure.Tests.Repository
{
    public class LocationRepositoryTests
    {
        private LocationRepository _locationRepository;

        [SetUp]
        public void Setup()
        {
            _locationRepository = new LocationRepository();
        }

        [Test]
        public void GetLocationById_ShouldReturnLocation_WhenLocationExists()
        {
            // Act
            var location = _locationRepository.GetLocationById(1);

            // Assert
            Assert.IsNotNull(location);
            Assert.AreEqual(1, location.Id);
        }

        [Test]
        public void GetAllLocations_ShouldReturnAllLocations()
        {
            // Act
            var locations = _locationRepository.GetAllLocations();

            // Assert
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations.Any());
        }
    }
}
