using NUnit.Framework;
using Home_Simulator.Components;
using System.Windows;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class AddUserDialogTests
    {
        private AddUserDialog _addUserDialog;

        [SetUp]
        public void Setup()
        {
            _addUserDialog = new AddUserDialog();
            // Assume InitializeComponent sets up necessary UI elements and their default states,
            // so in a real unit test environment, you might need to mock or simulate this.
        }

        [Test]
        public void OnAddUserClick_WithValidInputs_SetsDialogResultTrue()
        {
            // Arrange
            _addUserDialog.UserName = "John Doe";
            _addUserDialog.UserAge = 30;
            _addUserDialog.UserType = UserType.Standard; // Assuming UserType.Standard is a valid enum value

            // Act
            _addUserDialog.OnAddUserClick(null, new RoutedEventArgs());

            // Assert
            Assert.IsTrue(_addUserDialog.DialogResult);
        }

        [Test]
        public void OnAddUserClick_WithInvalidInputs_LeavesDialogResultNull()
        {
            // Arrange
            _addUserDialog.UserName = "";
            _addUserDialog.UserAge = -1;
            _addUserDialog.UserType = null;

            // Act
            _addUserDialog.OnAddUserClick(null, new RoutedEventArgs());

            // Assert
            Assert.IsNull(_addUserDialog.DialogResult);
            // Direct testing of UI element visibility (like ErrorMessage) is beyond the scope of this unit test example.
        }
    }
}
