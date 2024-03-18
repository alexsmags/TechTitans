using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class EditUserDialogTests
    {
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private Mock<ProfileReaderService> _mockProfileReaderService;
        private User _testUser;
        private EditUserDialog _editUserDialog;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _testUser = new User { Name = "John", Age = 30, Type = UserType.Standard };

            // Mock the SimulationViewModel
            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockSimulationViewModel.SetupAllProperties(); // This will allow us to mock property behaviors
            _mockSimulationViewModel.Object.CurrentUser = _testUser; // Assuming the current user is the user being edited

            // Mock the ProfileReaderService
            _mockProfileReaderService = new Mock<ProfileReaderService>();
            _mockProfileReaderService.Setup(x => x.SaveUsers(It.IsAny<List<User>>())); // Mocking the SaveUsers method to do nothing

            // Mock the ProfileReaderService Instance property to return our mock
            ProfileReaderService.Instance = _mockProfileReaderService.Object;

            // Initialize EditUserDialog with mocked ViewModel and test user
            _editUserDialog = new EditUserDialog(_testUser, _mockSimulationViewModel.Object);

            // Assume these properties are set to simulate the controls on the EditUserDialog
            _editUserDialog.NameTextBox = new TextBox() { Text = "Jane" };
            _editUserDialog.AgeTextBox = new TextBox() { Text = "25" };
            _editUserDialog.UserTypeComboBox = new ComboBox();
            _editUserDialog.UserTypeComboBox.Items.Add(UserType.Administrator);
            _editUserDialog.UserTypeComboBox.SelectedItem = UserType.Administrator;
        }

        [Test]
        public void Button_Click_ValidInput_UpdatesUserAndClosesDialog()
        {
            // Act
            _editUserDialog.Button_Click(null, null); // Simulating the button click

            // Assert
            _mockProfileReaderService.Verify(x => x.SaveUsers(It.IsAny<List<User>>()), Times.Once);
            _mockSimulationViewModel.Verify(x => x.InvokeCurentUserPropertyChanged(), Times.Once);
            _mockSimulationViewModel.Verify(x => x.InvokeAccess(), Times.Once);

            Assert.That(_editUserDialog.CurrentUser.Name, Is.EqualTo("Jane"));
            Assert.That(_editUserDialog.CurrentUser.Age, Is.EqualTo(25));
            Assert.That(_editUserDialog.CurrentUser.Type, Is.EqualTo(UserType.Administrator));
            Assert.That(_editUserDialog.DialogResult.HasValue && _editUserDialog.DialogResult.Value, Is.True);
        }


    }
}
