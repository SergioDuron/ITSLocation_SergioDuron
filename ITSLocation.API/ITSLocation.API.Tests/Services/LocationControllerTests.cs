using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ITSLocation.API.Controllers;
using ITSLocation.Application.Interfaces;
using ITSLocation.Domain.Entities;
using System.Collections.Generic;

namespace ITSLocation.API.Tests.Controllers
{
    public class LocationControllerTests
    {
        private Mock<ILocationService> _mockLocationService;
        private LocationController _locationController;

        [SetUp]
        public void Setup()
        {
            _mockLocationService = new Mock<ILocationService>();
            _locationController = new LocationController(_mockLocationService.Object);
        }

        [Test]
        public void GetLocationById_ShouldReturnOk_WhenLocationExists()
        {
            // Arrange
            var locationId = 1;
            var expectedLocation = new Location { Id = locationId, Name = "New York" };
            _mockLocationService.Setup(service => service.GetLocationById(locationId)).Returns(expectedLocation);

            // Act
            var result = _locationController.GetLocationById(locationId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedLocation, result.Value);
        }

        [Test]
        public void GetAllLocations_ShouldReturnOk()
        {
            // Arrange
            var expectedLocations = new List<Location>
            {
                new Location { Id = 1, Name = "New York" },
                new Location { Id = 2, Name = "Los Angeles" }
            };
            _mockLocationService.Setup(service => service.GetAllLocations()).Returns(expectedLocations);

            // Act
            var result = _locationController.GetAllLocations() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedLocations, result.Value);
        }
    }
}
