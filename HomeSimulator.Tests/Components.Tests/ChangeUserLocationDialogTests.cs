using Home_Simulator.Components;
using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using NUnit.Framework;
using System.Windows;
using System.Windows.Controls;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class ChangeUserLocationDialogTests
    {
        private ChangeUserLocationDialog _dialog;
        private SimulationViewModel _simulationViewModel;
        private TextBlock _noSelectionMessage;
        private ListBox _locationListBox;

        [SetUp]
        public void SetUp()
        {
            // Mock or create the necessary ViewModel.
            _simulationViewModel = new SimulationViewModel();

            // Mock the ListBox and TextBlock to simulate UI elements.
            _locationListBox = new ListBox();
            _noSelectionMessage = new TextBlock() { Visibility = Visibility.Collapsed };

            // Create an instance of the dialog using the mocked ViewModel.
            _dialog = new ChangeUserLocationDialog(_simulationViewModel)
            {
                // Assign the mocked ListBox and TextBlock to the dialog's properties or fields.
                LocationListBox = _locationListBox,
                NoSelectionMessage = _noSelectionMessage
            };
        }

        [Test]
        public void OkButton_Click_WithUserSelected_SetsDialogResultTrue()
        {
            // Arrange
            var location = new Location(); // Mock or create the location.
            _simulationViewModel.CurrentUser = new User(); // Mock or create the user.
            _locationListBox.Items.Add(location);
            _locationListBox.SelectedItem = location;

            // Act
            _dialog.OkButton_Click(null, new RoutedEventArgs());

            // Assert
            Assert.IsTrue(_dialog.DialogResult.HasValue && _dialog.DialogResult.Value,
                          "DialogResult should be true when a user and location are selected.");
        }

        [Test]
        public void OkButton_Click_WithNoUserSelected_ShowsErrorMessage()
        {
            // Arrange
            _simulationViewModel.CurrentUser = null; // Simulate no user being selected.
            var location = new Location(); // Mock or create the location.
            _locationListBox.Items.Add(location);
            _locationListBox.SelectedItem = location;

            // Act
            _dialog.OkButton_Click(null, new RoutedEventArgs());

            // Assert
            Assert.AreEqual(Visibility.Visible, _noSelectionMessage.Visibility,
                            "NoSelectionMessage should be visible when no user is selected.");
            Assert.IsFalse(_dialog.DialogResult.HasValue,
                           "DialogResult should not be set when no user is selected.");
        }
    }
}
