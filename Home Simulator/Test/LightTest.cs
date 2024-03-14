using NUnit.Framework;
using Home_Simulator.Models;

namespace Home_Simulator.Tests.Models
{
    [TestFixture]
    public class LightTests
    {
        [Test]
        public void SwitchOn_ShouldTurnOnLight()
        {
            // Arrange
            Light light = new Light();

            // Act
            light.SwitchOn();

            // Assert
            Assert.IsTrue(light.On);
        }

        [Test]
        public void SwitchOff_ShouldTurnOffLight()
        {
            // Arrange
            Light light = new Light();

            // Act
            light.SwitchOff();

            // Assert
            Assert.IsFalse(light.On);
        }
    }
}