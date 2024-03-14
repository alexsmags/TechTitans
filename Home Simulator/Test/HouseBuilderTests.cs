using NUnit.Framework;
using Home_Simulator.Models.HouseModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class HouseBuilderTests
    {
        [Test]
        public void BuildRoom_ShouldAddRoomToList()
        {
            // Arrange
            HouseBuilder houseBuilder = new HouseBuilder();

            // Act
            houseBuilder.BuildRoom();
            House house = houseBuilder.GetHouse();

            // Assert
            Assert.That(house.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddLights_ShouldAddLightsToLastRoom()
        {
            // Arrange
            HouseBuilder houseBuilder = new HouseBuilder();
            houseBuilder.BuildRoom();

            // Act
            houseBuilder.AddLights(3);
            House house = houseBuilder.GetHouse();

            // Assert
            Assert.AreEqual(3, house.Rooms[0].Lights.Count);
        }

        [Test]
        public void AddDoors_ShouldAddDoorsToLastRoom()
        {
            // Arrange
            HouseBuilder houseBuilder = new HouseBuilder();
            houseBuilder.BuildRoom();

            // Act
            houseBuilder.AddDoors(2);
            House house = houseBuilder.GetHouse();

            // Assert
            Assert.AreEqual(2, house.Rooms[0].Doors.Count);
        }

        [Test]
        public void AddWindows_ShouldAddWindowsToLastRoom()
        {
            // Arrange
            HouseBuilder houseBuilder = new HouseBuilder();
            houseBuilder.BuildRoom();

            // Act
            houseBuilder.AddWindows(4);
            House house = houseBuilder.GetHouse();

            // Assert
            Assert.AreEqual(4, house.Rooms[0].Windows.Count);
        }

        [Test]
        public void NameRoom_ShouldSetNameOfLastRoom()
        {
            // Arrange
            HouseBuilder houseBuilder = new HouseBuilder();
            houseBuilder.BuildRoom();

            // Act
            houseBuilder.NameRoom("Living Room");
            House house = houseBuilder.GetHouse();

            // Assert
            Assert.That(house.Rooms[0].Name, Is.EqualTo("Living Room"));
        }
    }
}