using NUnit.Framework;
using Home_Simulator.Models.HouseModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class HouseTests
    {
        [Test]
        public void AddRoom_ShouldAddRoomToList()
        {
            // Arrange
            House house = new House();
            Room room = new Room();

            // Act
            house.AddRoom(room);

            // Assert
            Assert.Contains(room, house.Rooms);
        }
    }
}