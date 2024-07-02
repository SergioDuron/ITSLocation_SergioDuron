using NUnit.Framework;
using Moq;
using ITSLocation.Application.Interfaces;
using ITSLocation.Application.Services;
using ITSLocation.Domain.Entities;
using ITSLocation.Domain.RepositoryInterfaces;
using System.Collections.Generic;

namespace ITSLocation.Application.Tests.Services
{
    public class LocationServiceTests
    {
        private Mock<ILocationRepository> _mockLocationRepository;
        private ILocationService _locationService;

        [SetUp]
        public void Setup()
        {
            _mockLocationRepository = new Mock<ILocationRepository>();
            _locationService = new LocationService(_mockLocationRepository.Object);
        }

        [Test]
        public void GetLocationById_ShouldReturnLocation_WhenLocationExists()
        {
            // Arrange
            var locationId = 1;
            var expectedLocation = new Location { Id = locationId, Name = "New York" };
            _mockLocationRepository.Setup(repo => repo.GetLocationById(locationId)).Returns(expectedLocation);

            // Act
            var result = _locationService.GetLocationById(locationId);

            // Assert
            Assert.AreEqual(expectedLocation, result);
        }

        [Test]
        public void GetAllLocations_ShouldReturnAllLocations()
        {
            // Arrange
            var expectedLocations = new List<Location>
            {
                new Location { Id = 1, Name = "New York" },
                new Location { Id = 2, Name = "Los Angeles" }
            };
            _mockLocationRepository.Setup(repo => repo.GetAllLocations()).Returns(expectedLocations);

            // Act
            var result = _locationService.GetAllLocations();

            // Assert
            Assert.AreEqual(expectedLocations, result);
        }
    }
}
