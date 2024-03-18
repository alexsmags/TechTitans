using Moq;
using NUnit.Framework;
using Home_Simulator.Commands;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using System.Collections.ObjectModel;
using System;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class RemoveUserCommandTests
    {
        private RemoveUserCommand _command;
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private Mock<IUserSelectionDialog> _mockUserSelectionDialog;
        private Mock<IProfileReaderService> _mockProfileReaderService;
        private ObservableCollection<User> _users;

        [SetUp]
        public void SetUp()
        {
            _users = new ObservableCollection<User>
            {
                new User { Name = "John Doe", Age = 30, Type = UserType.Standard },
                new User { Name = "Jane Doe", Age = 25, Type = UserType.Admin }
            };

            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockSimulationViewModel.Setup(vm => vm.users).Returns(_users);
            _mockSimulationViewModel.SetupAllProperties(); // Setup property behavior for CurrentUser

            _mockUserSelectionDialog = new Mock<IUserSelectionDialog>();
            _mockProfileReaderService = new Mock<IProfileReaderService>();

            // Assuming dialog selection success and user selection
            _mockUserSelectionDialog.Setup(d => d.ShowDialog()).Returns(true);
            _mockUserSelectionDialog.Setup(d => d.SelectedUser).Returns(_users.First());

            // Setup static instance access
            ProfileReaderService.Instance = _mockProfileReaderService.Object;

            _command = new RemoveUserCommand(_mockSimulationViewModel.Object, _mockUserSelectionDialog.Object);
        }

        [Test]
        public void Execute_WhenUserSelected_RemovesUser()
        {
            // Assume current user is the first user
            _mockSimulationViewModel.Object.CurrentUser = _users.First();

            // Act
            _command.Execute(null);

            // Assert
            _mockProfileReaderService.Verify(s => s.RemoveUser(It.IsAny<User>()), Times.Once);
            Assert.AreEqual(1, _users.Count);
            Assert.IsNull(_mockSimulationViewModel.Object.CurrentUser);
        }
    }
}
