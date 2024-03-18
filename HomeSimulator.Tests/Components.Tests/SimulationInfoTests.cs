using NUnit.Framework;
using Home_Simulator.Components;
using System;

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class SimulationInfoTests
    {
        [Test]
        public void SimulationTimeProperty_WhenSet_UpdatesCorrectly()
        {
            // Arrange
            var simulationInfo = new SimulationInfo();
            var expectedTime = new DateTime(2023, 1, 1, 12, 0, 0);

            // Act
            simulationInfo.SimulationTime = expectedTime;

            // Assert
            Assert.AreEqual(expectedTime, simulationInfo.SimulationTime);
        }
    }
}
