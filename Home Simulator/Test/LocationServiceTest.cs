using NUnit.Framework;
using Home_Simulator.Models.HouseModels;
using System.Collections.ObjectModel;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class LocationServiceTests
    {
        [Test]
        public void AddLocation_ShouldAddLocationToList()
        {
            // Arrange
            LocationService locationService = new LocationService();
            Location location = new Room();

            // Act
            locationService.AddLocation(location);

            // Assert
            Assert.That(locationService.Locations, Does.Contain(location));
            locationService.RemoveLocation(location);
        }

        [Test]
        public void AddRooms_ShouldAddRoomsToList()
        {
            // Arrange
            LocationService locationService = new LocationService();
            ObservableCollection<Room> rooms = new ObservableCollection<Room>
            {
                new Room(),
                new Room(),
                new Room()
            };

            // Act
            locationService.AddRooms(rooms);

            // Assert
            Assert.That(locationService.Locations, Has.Count.EqualTo(rooms.Count));
            foreach (var room in rooms)
            {
                Assert.Contains(room, locationService.Locations);
            }
        }

        [Test]
        public void RemoveLocation_ShouldRemoveLocationFromList()
        {
            // Arrange
            LocationService locationService = new LocationService();
            Location location = new Room();
            locationService.AddLocation(location);

            // Act
            locationService.RemoveLocation(location);

            // Assert
            Assert.IsFalse(locationService.Locations.Contains(location));
        }
    }
}