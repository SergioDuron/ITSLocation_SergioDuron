using NUnit.Framework;
using ITSLocation.Domain.Entities;

namespace ITSLocation.Domain.Tests.Entities
{
    public class LocationTests
    {
        [Test]
        public void Location_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var location = new Location { Id = 1, Name = "New York" };

            // Assert
            Assert.AreEqual(1, location.Id);
            Assert.AreEqual("New York", location.Name);
        }
    }
}
