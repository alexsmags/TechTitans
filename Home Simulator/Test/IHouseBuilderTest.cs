using NUnit.Framework;
using Home_Simulator.Models.HouseModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class IHouseBuilderTests
    {
        [Test]
        public void BuildRoom_ShouldBuildRoom()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();

            // Act
            houseBuilder.BuildRoom();

            // Assert
            // Add your assertions here
        }

        [Test]
        public void AddLights_ShouldAddLights()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();
            int numberOfLights = 5;

            // Act
            houseBuilder.AddLights(numberOfLights);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void AddDoors_ShouldAddDoors()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();
            int numberOfDoors = 3;

            // Act
            houseBuilder.AddDoors(numberOfDoors);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void AddWindows_ShouldAddWindows()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();
            int numberOfWindows = 4;

            // Act
            houseBuilder.AddWindows(numberOfWindows);

            // Assert
            // Add your assertions here
        }

        [Test]
        public void GetHouse_ShouldReturnHouse()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();

            // Act
            House house = houseBuilder.GetHouse();

            // Assert
            // Add your assertions here
        }

        [Test]
        public void NameRoom_ShouldSetName()
        {
            // Arrange
            IHouseBuilder houseBuilder = new HouseBuilder();
            string roomName = "Living Room";

            // Act
            houseBuilder.NameRoom(roomName);

            // Assert
            // Add your assertions here
        }
    }
}