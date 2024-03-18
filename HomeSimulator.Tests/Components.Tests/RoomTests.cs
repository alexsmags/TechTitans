using NUnit.Framework;
using Home_Simulator.Components;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void ToggleLights_WhenCalled_ChangesLightStatus()
        {
            // Arrange
            var room = new Room();
            var initialStatus = room.LightStatus;

            // Act
            room.ToggleLights();

            // Assert
            Assert.AreNotEqual(initialStatus, room.LightStatus);
        }
    }
}
