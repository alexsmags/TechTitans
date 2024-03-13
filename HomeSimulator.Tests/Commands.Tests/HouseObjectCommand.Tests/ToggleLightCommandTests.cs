using NUnit.Framework;
using Home_Simulator.Commands.HouseObjectCommands;
using Home_Simulator.Models;

namespace Home_Simulator.Tests.Commands.HouseObjectCommands
{
    [TestFixture]
    public class ToggleLightCommandTests
    {
        private ToggleLightCommand _command;
        private Light _light;

        [SetUp]
        public void Setup()
        {
            _command = new ToggleLightCommand();
            _light = new Light(); // Assume Light has a default state of Off (On = false).
        }

        [Test]
        public void CanExecute_ReturnsTrue_ForLightObject()
        {
            bool result = _command.CanExecute(_light);
            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_ReturnsFalse_ForNonLightObject()
        {
            var nonLightObject = new object();
            bool result = _command.CanExecute(nonLightObject);
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_SwitchesLightOn_WhenLightIsOff()
        {
            // Initially, the light is off.
            Assert.IsFalse(_light.On);

            _command.Execute(_light);

            // Verify the light is switched on.
            Assert.IsTrue(_light.On);
        }

        [Test]
        public void Execute_SwitchesLightOff_WhenLightIsOn()
        {
            // Manually turn the light on for this test.
            _light.SwitchOn();
            Assert.IsTrue(_light.On);

            _command.Execute(_light);

            // Verify the light is switched off.
            Assert.IsFalse(_light.On);
        }
    }
}
