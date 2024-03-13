using Home_Simulator.Components;
using NUnit.Framework;
using System;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class ChangeDateTimeDialogTests
    {
        private ChangeDateTimeDialog _dialog;
        private DateTimeModel _dateTimeModel;

        [SetUp]
        public void SetUp()
        {
            _dateTimeModel = new DateTimeModel(); // Mock or create as necessary.
            _dialog = new ChangeDateTimeDialog(_dateTimeModel);
        }

        [Test]
        public void OnUpdateDateTimeClick_WhenValidDateTime_ShouldSetSelectedDateTime()
        {
            // Arrange
            var expectedDateTime = new DateTime(2024, 3, 13, 15, 0, 0);
            SetDialogState(expectedDateTime, "15:00"); // Assume these are methods you can call for testing.

            // Act
            _dialog.OnUpdateDateTimeClick(null, null); // Direct invocation might require the method to be public or internal.

            // Assert
            Assert.AreEqual(expectedDateTime, _dialog.SelectedDateTime, "The SelectedDateTime should match the expected date and time.");
            Assert.IsTrue(_dialog.DialogResult.HasValue && _dialog.DialogResult.Value, "DialogResult should be true when valid date and time are set.");
        }

        [Test]
        public void OnUpdateDateTimeClick_WhenInvalidTimeFormat_ShouldNotSetSelectedDateTime()
        {
            // Arrange
            SetDialogState(DateTime.Now, "invalid_time"); // Set invalid time format for testing.

            // Act
            _dialog.OnUpdateDateTimeClick(null, null);

            // Assert
            Assert.IsFalse(_dialog.DialogResult.HasValue, "DialogResult should be false when invalid time format is set.");
        }

        // These methods would need to exist within your ChangeDateTimeDialog class, 
        // or you would need to find another way to simulate setting these values for testing.
        private void SetDialogState(DateTime selectedDate, string timeText)
        {
            // These assignments are illustrative. In an actual unit test, you would need to have properties or methods
            // that can be set or called directly to simulate the behavior of the datePicker and timeTextBox.

            // Simulate setting the datePicker's SelectedDate.
            _dialog.SetSelectedDate(selectedDate);

            // Simulate setting the timeTextBox's Text.
            _dialog.SetTimeText(timeText);

            // This assumes that the SetSelectedDate and SetTimeText methods are implemented in your ChangeDateTimeDialog
            // to abstract away the direct interaction with the datePicker and timeTextBox.
            // This is part of making the code more testable by avoiding direct UI manipulation in unit tests.
        }

    }
}
