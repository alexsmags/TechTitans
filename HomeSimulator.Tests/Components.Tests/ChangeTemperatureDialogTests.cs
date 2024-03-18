using Home_Simulator.Components;
using NUnit.Framework;
using System.Windows;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class ChangeTemperatureDialogTests
    {
        private ChangeTemperatureDialog _dialog;

        [SetUp]
        public void SetUp()
        {
            // Initialize the dialog with a default temperature value.
            _dialog = new ChangeTemperatureDialog("20");
            // Assume InitializeComponent sets up necessary UI elements and their default states.
        }

        [Test]
        public void OKButton_Click_ValidTemperature_SetsDialogResultTrue()
        {
            // Arrange
            SetTemperatureValue(25.0); // Assuming this is a valid temperature value.

            // Act
            _dialog.OKButton_Click(null, new RoutedEventArgs());

            // Assert
            Assert.IsTrue(_dialog.DialogResult.HasValue && _dialog.DialogResult.Value,
                          "DialogResult should be true for a valid temperature value.");
        }

        [Test]
        public void OKButton_Click_InvalidTemperature_LeavesDialogResultFalse()
        {
            // Arrange
            SetTemperatureValue(double.NaN); // NaN is not a valid temperature value.

            // Act
            _dialog.OKButton_Click(null, new RoutedEventArgs());

            // Assert
            Assert.IsFalse(_dialog.DialogResult.HasValue,
                           "DialogResult should remain unset for an invalid temperature value.");
        }

        [Test]
        public void setTemperature_ValueChanged_UpdatesTemperatureDisplay()
        {
            // Arrange
            double newTemperature = 18.0;

            // Act
            _dialog.setTemperature_ValueChanged(null,
                new RoutedPropertyChangedEventArgs<double>(0, newTemperature));

            // Assert
            string expectedDisplay = "Temperature: " + newTemperature.ToString("N0") + "°C";
            Assert.AreEqual(expectedDisplay, _dialog.tempDisplay.Text,
                            "Temperature display should update when the temperature value changes.");
        }

        // Helper method to set the temperature value in the dialog for testing.
        // This method would need to exist within your ChangeTemperatureDialog class, or you would need to find another
        // way to simulate setting these values for testing.
        private void SetTemperatureValue(double temperature)
        {
            // Simulate setting the temperature slider's Value property for the purposes of the unit test.
            // You would need to simulate this as setting actual UI elements directly in a test is not typically possible.
            _dialog.setTemperature.Value = temperature;
            _dialog.UpdateTemperatureDisplay(); // Update display to reflect the change.
        }
    }
}
