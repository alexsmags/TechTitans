using NUnit.Framework;
using Home_Simulator.Commands.HouseObjectCommands;
using Home_Simulator.Models.HouseModels;
using System;

namespace Home_Simulator.Tests.Commands.HouseObjectCommands
{
    [TestFixture]
    public class ToggleOpenCloseWindowCommandTests
    {
        [Test]
        public void CanExecute_ReturnsTrue_ForWindowObject()
        {
            // Arrange
            var command = new ToggleOpenCloseWindowCommand();
            var window = new Window();

            // Act
            bool canExecute = command.CanExecute(window);

            // Assert
            Assert.IsTrue(canExecute, "Command should be executable for Window object.");
        }

        [Test]
        public void CanExecute_ReturnsFalse_ForNonWindowObject()
        {
            // Arrange
            var command = new ToggleOpenCloseWindowCommand();
            var nonWindowObject = new object();

            // Act
            bool canExecute = command.CanExecute(nonWindowObject);

            // Assert
            Assert.IsFalse(canExecute, "Command should not be executable for non-Window object.");
        }

        [Test]
        public void Execute_OpensClosedWindow()
        {
            // Arrange
            var command = new ToggleOpenCloseWindowCommand();
            var window = new Window { IsOpen = false };

            // Act
            command.Execute(window);

            // Assert
            Assert.IsTrue(window.IsOpen, "Window should be open after execution.");
        }

        [Test]
        public void Execute_ClosesOpenWindow()
        {
            // Arrange
            var command = new ToggleOpenCloseWindowCommand();
            var window = new Window { IsOpen = true };

            // Act
            command.Execute(window);

            // Assert
            Assert.IsFalse(window.IsOpen, "Window should be closed after execution.");
        }
    }
}
