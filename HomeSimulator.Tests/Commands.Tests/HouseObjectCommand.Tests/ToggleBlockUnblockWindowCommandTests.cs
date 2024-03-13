using Home_Simulator.Commands.HouseObjectCommands;
using Home_Simulator.Models.HouseModels;
using NUnit.Framework;

namespace Home_Simulator.Tests.Commands.HouseObjectCommands
{
    [TestFixture]
    public class ToggleBlockUnblockWindowCommandTests
    {
        [Test]
        public void CanExecute_ReturnsTrue_WhenParameterIsWindow()
        {
            // Arrange
            var command = new ToggleBlockUnblockWindowCommand();
            var window = new Window();

            // Act
            bool result = command.CanExecute(window);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_ReturnsFalse_WhenParameterIsNotWindow()
        {
            // Arrange
            var command = new ToggleBlockUnblockWindowCommand();
            var notAWindow = new object(); // Simulate a non-Window parameter

            // Act
            bool result = command.CanExecute(notAWindow);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_BlocksWindow_WhenWindowIsNotBlocked()
        {
            // Arrange
            var command = new ToggleBlockUnblockWindowCommand();
            var window = new Window { IsBlocked = false };

            // Act
            command.Execute(window);

            // Assert
            Assert.IsTrue(window.IsBlocked);
        }

        [Test]
        public void Execute_UnblocksWindow_WhenWindowIsBlocked()
        {
            // Arrange
            var command = new ToggleBlockUnblockWindowCommand();
            var window = new Window { IsBlocked = true };

            // Act
            command.Execute(window);

            // Assert
            Assert.IsFalse(window.IsBlocked);
        }
    }
}
