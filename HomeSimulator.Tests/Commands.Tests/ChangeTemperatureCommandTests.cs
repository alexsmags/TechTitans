using Moq;
using NUnit.Framework;
using Home_Simulator.Commands;
using Home_Simulator.Components;
using Home_Simulator.ViewModels;
using System;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class ChangeTemperatureCommandTests
    {
        private Mock<ISimulationViewModel> _mockSimulationViewModel;
        private ChangeTemperatureCommand _command;
        private Mock<IChangeTemperatureDialog> _mockDialog;

        [SetUp]
        public void SetUp()
        {
            // Setup mock for the SimulationViewModel
            _mockSimulationViewModel = new Mock<ISimulationViewModel>();

            // Setup mock for the ChangeTemperatureDialog
            _mockDialog = new Mock<IChangeTemperatureDialog>();
            _mockDialog.Setup(m => m.ShowDialog()).Returns(true); // Simulate dialog returning true for DialogResult
            _mockDialog.SetupProperty(m => m.SelectedTemperature, "22°C"); // Setup SelectedTemperature to return a test value

            // Initialize the command with the mocked ViewModel
            _command = new ChangeTemperatureCommand(_mockSimulationViewModel.Object);

            // Assuming Dependency Injection or some factory method that you can mock/control to return your mocked dialog
            DialogFactory.SetMockDialog(_mockDialog.Object);
        }

        [Test]
        public void Execute_UpdatesOutsideTemperature_WhenDialogResultIsTrue()
        {
            // Act
            _command.Execute(null);

            // Assert
            _mockSimulationViewModel.VerifySet(vm => vm.OutsideTemperature = "22°C", Times.Once, "The outside temperature should be updated to the selected temperature from the dialog.");
        }
    }
}
