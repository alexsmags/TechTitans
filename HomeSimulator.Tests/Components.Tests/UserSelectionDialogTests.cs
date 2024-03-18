using NUnit.Framework;
using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class UserSelectionDialogTests
    {
        private UserSelectionDialog _dialog;
        private List<User> _users;

        [SetUp]
        public void SetUp()
        {
            // Arrange - Create a list of users for testing
            _users = new List<User>
            {
                new User { Name = "Alice", Age = 30, Type = UserType.Admin },
                new User { Name = "Bob", Age = 25, Type = UserType.Standard }
            };

            // Create the dialog with the test users
            _dialog = new UserSelectionDialog(_users);
            // Assuming InitializeComponent can be simulated or the relevant properties can be manually set
            _dialog.UsersListBox = new ListBox { ItemsSource = _users };
        }

        [Test]
        public void UserSelectionDialog_InitializesWithUsersList()
        {
            // Assert
            Assert.AreEqual(_users, _dialog.UsersListBox.ItemsSource);
        }

        [Test]
        public void OkButton_Click_WithSelectedUser_SetsDialogResultTrue()
        {
            // Simulate selecting a user
            _dialog.UsersListBox.SelectedItem = _users.First();

            // Simulate clicking the OK button
            _dialog.OkButton_Click(null, new RoutedEventArgs());

            // Assert
            Assert.IsTrue(_dialog.DialogResult.HasValue && _dialog.DialogResult.Value);
            Assert.IsNotNull(_dialog.SelectedUser);
            Assert.AreEqual(_users.First(), _dialog.SelectedUser);
        }
    }
}
