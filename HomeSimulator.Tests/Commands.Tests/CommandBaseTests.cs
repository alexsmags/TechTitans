using NUnit.Framework;
using Home_Simulator.Commands;
using System;
using System.Windows.Input;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class CommandBaseTests
    {
        private class TestCommand : CommandBase
        {
            public override void Execute(object parameter)
            {
                // Mock implementation for testing.
            }
        }

        private TestCommand _testCommand;

        [SetUp]
        public void SetUp()
        {
            _testCommand = new TestCommand();
        }

        [Test]
        public void CanExecute_Always_ReturnsTrue()
        {
            bool result = _testCommand.CanExecute(null);

            Assert.IsTrue(result, "CanExecute should always return true.");
        }

        [Test]
        public void OnCanExecuteChanged_Raises_CanExecuteChangedEvent()
        {
            bool wasRaised = false;

            // Subscribe to the event
            _testCommand.CanExecuteChanged += (sender, e) => { wasRaised = true; };

            // Trigger the event
            _testCommand.OnCanExecuteChanged();

            Assert.IsTrue(wasRaised, "OnCanExecuteChanged should raise the CanExecuteChanged event.");
        }
    }
}
