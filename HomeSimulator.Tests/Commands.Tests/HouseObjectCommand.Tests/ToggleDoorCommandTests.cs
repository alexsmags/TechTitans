using Home_Simulator.Commands.HouseObjectCommands;
using Home_Simulator.Models.HouseModels;
using NUnit.Framework;

namespace Home_Simulator.Tests.Commands.HouseObjectCommands
{
    [TestFixture]
    public class ToggleDoorCommandTests
    {
        [Test]
        public void CanExecute_ReturnsTrue_WhenParameterIsDoor()
        {
            // Arrange
            var command = new ToggleDoorCommand();
            var door = new Door();

            // Act
            bool result = command.CanExecute(door);

            // Assert
            Assert.IsTrue(result, "CanExecute should return true when the parameter is a Door.");
        }

        [Test]
        public void CanExecute_ReturnsFalse_WhenParameterIsNotDoor()
        {
            // Arrange
            var command = new ToggleDoorCommand();
            var notADoor = new object();

            // Act
            bool result = command.CanExecute(notADoor);

            // Assert
            Assert.IsFalse(result, "CanExecute should return false when the parameter is not a Door.");
        }

        [Test]
        public void Execute_OpensDoor_WhenDoorIsInitiallyClosed()
        {
            // Arrange
            var command = new ToggleDoorCommand();
            var door = new Door { IsOpen = false };

            // Act
            command.Execute(door);

            // Assert
            Assert.IsTrue(door.IsOpen, "Execute should open the door when it is initially closed.");
        }

        [Test]
        public void Execute_ClosesDoor_WhenDoorIsInitiallyOpen()
        {
            // Arrange
            var command = new ToggleDoorCommand();
            var door = new Door { IsOpen = true };

            // Act
            command.Execute(door);

            // Assert
            Assert.IsFalse(door.IsOpen, "Execute should close the door when it is initially open.");
        }
    }
}
