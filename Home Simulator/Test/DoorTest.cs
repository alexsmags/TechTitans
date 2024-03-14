using NUnit.Framework;
using Home_Simulator.Models.HouseModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class DoorTests
    {
        [Test]
        public void OpenDoor_ShouldSetIsOpenToTrue()
        {
            // Arrange
            Door door = new();

            // Act
            door.OpenDoor();

            // Assert
            Assert.IsTrue(door.IsOpen);
        }

        [Test]
        public void CloseDoor_ShouldSetIsOpenToFalse()
        {
            // Arrange
            Door door = new Door();

            // Act
            door.CloseDoor();

            // Assert
            Assert.IsFalse(door.IsOpen);
        }

        
    }
}
