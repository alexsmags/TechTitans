using Home_Simulator.Commands;
using Home_Simulator.Components;
using Home_Simulator.Models;
using Home_Simulator.ViewModels;
using Moq;
using NUnit.Framework;
using System;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class ChangeDateTimeCommandTests
    {
        private ChangeDateTimeCommand _command;
        private Mock<SimulationViewModel> _mockViewModel;
        private Mock<ChangeDateTimeDialog> _mockDialog;
        private DateTime _testDateTime;

        [SetUp]
        public void SetUp()
        {
            // Setup the mock ViewModel
            _mockViewModel = new Mock<SimulationViewModel>();
            _mockViewModel.SetupAllProperties();
            _mockViewModel.Object.simulationModel = new SimulationModel();

            // Mock the ChangeDateTimeDialog to simulate user interactions
            _testDateTime = new DateTime(2023, 01, 01, 12, 00, 00);
            _mockDialog = new Mock<ChangeDateTimeDialog>(_mockViewModel.Object.simulationModel) { CallBase = true };
            _mockDialog.Setup(d => d.ShowDialog()).Returns(true);
            _mockDialog.Setup(d => d.SelectedDateTime).Returns(_testDateTime);

            // Setup the command with the mocked ViewModel
            _command = new ChangeDateTimeCommand(_mockViewModel.Object);

            // Inject the mock dialog factory into the command
            _command.CreateDialog = () => _mockDialog.Object;
        }

        [Test]
        public void Execute_WhenDialogConfirms_UpdatesSimulationModelDateTime()
        {
            // Act
            _command.Execute(null);

            // Assert - Verify that the date and time were updated in the simulation model
            _mockViewModel.VerifySet(vm => vm.simulationModel.SimulationDate = _testDateTime.Date, Times.Once);
            _mockViewModel.VerifySet(vm => vm.simulationModel.SimulationTime = _testDateTime.TimeOfDay, Times.Once);

            // Verify that the view model's CurrentDate and CurrentTime properties were updated
            Assert.AreEqual(_testDateTime.TimeOfDay.ToString(), _mockViewModel.Object.CurrentDate);
            Assert.AreEqual(_testDateTime.TimeOfDay.ToString(), _mockViewModel.Object.CurrentTime);
        }
    }
}
