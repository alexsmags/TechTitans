using Moq;
using NUnit.Framework;
using Home_Simulator.Commands;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using System.Collections.Generic;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class ChangeUserCommandTests
    {
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private ChangeUserCommand _changeUserCommand;
        private Mock<IUserSelectionDialog> _mockUserSelectionDialog; // Assume IUserSelectionDialog is an interface for UserSelectionDialog

        [SetUp]
        public void SetUp()
        {
            // Mock the SimulationViewModel
            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockSimulationViewModel.SetupAllProperties();
            _mockSimulationViewModel.Object.users = new List<User>
            {
                new User { Name = "User1" },
                new User { Name = "User2" }
            };

            // Mock the UserSelectionDialog and its behavior
            _mockUserSelectionDialog = new Mock<IUserSelectionDialog>();
            _mockUserSelectionDialog.Setup(m => m.ShowDialog()).Returns(true); // Simulate user selected a user
            _mockUserSelectionDialog.Setup(m => m.SelectedUser).Returns(new User { Name = "User1" }); // Assume user selected "User1"

            // Setup the factory to return the mocked UserSelectionDialog
            UserSelectionDialogFactory.SetMock(_mockUserSelectionDialog.Object);

            _changeUserCommand = new ChangeUserCommand(_mockSimulationViewModel.Object);
        }

        [Test]
        public void Execute_UserSelectionDialogReturnsTrue_UpdatesCurrentUser()
        {
            // Act
            _changeUserCommand.Execute(null);

            // Assert
            _mockSimulationViewModel.VerifySet(vm => vm.CurrentUser = It.IsAny<User>(), Times.Once);
            Assert.AreEqual("User1", _mockSimulationViewModel.Object.CurrentUser.Name, "CurrentUser should be updated to the selected user.");
        }
    }
}
