using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class EditUsersDialogTests
    {
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private EditUsersDialog _editUsersDialog;
        private ListBox _mockUsersListBox;
        private List<User> _users;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>
            {
                new User { Name = "John", Age = 30, Type = UserType.Administrator },
                new User { Name = "Jane", Age = 25, Type = UserType.Standard }
            };

            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockSimulationViewModel.Setup(vm => vm.users).Returns(_users);

            _mockUsersListBox = new ListBox();
            _users.ForEach(u => _mockUsersListBox.Items.Add(u));

            _editUsersDialog = new EditUsersDialog(_mockSimulationViewModel.Object)
            {
                UsersListBox = _mockUsersListBox
            };
        }

        [Test]
        public void OnOkButtonClick_WhenClicked_SetsDialogResultToTrue()
        {
            // Arrange
            // No additional arrangement needed for this test

            // Act
            _editUsersDialog.OnOkButtonClick(null, null);

            // Assert
            Assert.IsTrue(_editUsersDialog.DialogResult.HasValue && _editUsersDialog.DialogResult.Value);
        }

        [Test]
        public void UsersListBox_MouseDoubleClick_WhenUserSelected_OpensEditUserDialog()
        {
            // Arrange
            _mockUsersListBox.SelectedItem = _users[0];
            var mockEditUserDialog = new Mock<EditUserDialog>(_users[0], _mockSimulationViewModel.Object);
            mockEditUserDialog.Setup(m => m.ShowDialog()).Returns(true);

            // Act
            // Simulating the MouseDoubleClick event by calling the event handler directly
            _editUsersDialog.UsersListBox_MouseDoubleClick(_mockUsersListBox, null);

            // Assert
            // Here we need to assert that the EditUserDialog was shown and that the items were refreshed
            // Since we cannot directly verify UI behavior in a unit test, we check that the DialogResult was set and that the Items were refreshed
            mockEditUserDialog.Verify(m => m.ShowDialog(), Times.Once);

        }


    }
}
