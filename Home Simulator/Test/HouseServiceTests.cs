using NUnit.Framework;
using Home_Simulator.Models;
using Home_Simulator.Models.HouseModels;
using Moq;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class HouseServiceTests
    {
        private HouseService _houseService;
        private Mock<IHouseBuilder> _mockBuilder;

        [SetUp]
        public void SetUp()
        {
            _mockBuilder = new Mock<IHouseBuilder>();
            _houseService = new HouseService(_mockBuilder.Object);
        }

        [Test]
        public void CreateHouseFromTextFile_ShouldReturnHouse()
        {
            // Arrange
            string fileContent = "Living Room: Size=200, Windows=3";

            // Act
            var result = _houseService.CreateHouseFromTextFile(fileContent);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<House>(result);
        }

        // Add more test cases for different scenarios

        // ...
    }
}