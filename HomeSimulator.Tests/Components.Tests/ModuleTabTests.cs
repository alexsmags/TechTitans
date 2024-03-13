using NUnit.Framework;
using Home_Simulator.Components;
using System.Windows.Controls;
using System.Windows;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class ModuleTabTests
    {
        private ModuleTab _moduleTab;

        [SetUp]
        public void SetUp()
        {
            _moduleTab = new ModuleTab();
            // Assuming InitializeComponent simulates loading of the component,
            // and these controls are publicly accessible for the test.
            _moduleTab.chkBackyard = new CheckBox();
            _moduleTab.chkGarage = new CheckBox();
            _moduleTab.chkMain = new CheckBox();
            _moduleTab.btnToggle = new Button();
        }

        [Test]
        public void BtnToggle_Click_TogglesCheckBoxesAndButtonText()
        {
            // Initial state, assuming unchecked
            Assert.IsFalse(_moduleTab.chkBackyard.IsChecked);
            Assert.IsFalse(_moduleTab.chkGarage.IsChecked);
            Assert.IsFalse(_moduleTab.chkMain.IsChecked);
            Assert.AreEqual("All", _moduleTab.btnToggle.Content);

            // Act - simulate button click
            _moduleTab.btnToggle_Click(_moduleTab.btnToggle, new RoutedEventArgs());

            // Assert - check boxes should now be checked, and button content updated
            Assert.IsTrue(_moduleTab.chkBackyard.IsChecked);
            Assert.IsTrue(_moduleTab.chkGarage.IsChecked);
            Assert.IsTrue(_moduleTab.chkMain.IsChecked);
            Assert.AreEqual("None", _moduleTab.btnToggle.Content);

            // Act again - simulate button click to toggle back
            _moduleTab.btnToggle_Click(_moduleTab.btnToggle, new RoutedEventArgs());

            // Assert - check boxes should now be unchecked, and button content reverted
            Assert.IsFalse(_moduleTab.chkBackyard.IsChecked);
            Assert.IsFalse(_moduleTab.chkGarage.IsChecked);
            Assert.IsFalse(_moduleTab.chkMain.IsChecked);
            Assert.AreEqual("All", _moduleTab.btnToggle.Content);
        }
    }
}
