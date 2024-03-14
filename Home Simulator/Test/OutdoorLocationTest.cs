using NUnit.Framework;
using Home_Simulator.Models.HouseModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class OutdoorLocationTests
    {
        [Test]
        public void Constructor_ShouldSetDefaultName()
        {
            // Arrange
            OutdoorLocation outdoorLocation = new();

            // Assert
            Assert.AreEqual("Outdoor", outdoorLocation.Name);
        }
    }
}