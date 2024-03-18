using NUnit.Framework;
using Moq;
using Home_Simulator.Commands;
using Home_Simulator.Components;
using Home_Simulator.ViewModels;
using System.Windows;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class EditUsersCommandTests
    {
        private EditUsersCommand _command;
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private Mock<IWindowService> _mockWindowService; // Assume this service for creating and showing windows

        [SetUp]
        public void SetUp()
        {
            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockWindowService = new Mock<IWindowService>();

            // Set up the window service mock to track dialog showing
            _mockWindowService.Setup(service =>
                service.ShowDialog<EditUsersDialog>(It.IsAny<SimulationViewModel>()))
                .Returns(true); // Assume dialog result is true for testing

            _command = new EditUsersCommand(_mockSimulationViewModel.Object, _mockWindowService.Object);
        }

        [Test]
        public void Execute_ShowsEditUsersDialog()
        {
            // Act
            _command.Execute(null);

            // Assert
            _mockWindowService.Verify(service =>
                service.ShowDialog<EditUsersDialog>(It.IsAny<SimulationViewModel>()),
                Times.Once, "EditUsersDialog should be shown exactly once.");
        }
    }
}
