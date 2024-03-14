using Home_Simulator.Models.HouseSimulationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Home_Simulator.Tests.Models.HouseSimulationModels
{
    [TestFixture]
    internal class DateTimeModelTests
    {
        [Test]
        public void IncrementTime_ShouldIncreaseSimulationTimeByTimeSpeed()
        {
            // Arrange
            var dateTimeModel = new DateTimeModel();
            dateTimeModel.TimeSpeed = 2;

            // Act
            dateTimeModel.IncrementTime();

            // Assert
            Assert.That(dateTimeModel.SimulationTime, Is.EqualTo(TimeSpan.FromSeconds(2)));
        }

        [Test]
        public void IncrementTime_ShouldIncrementSimulationDateWhenSimulationTimeExceeds24Hours()
        {
            // Arrange
            var dateTimeModel = new DateTimeModel();
            dateTimeModel.TimeSpeed = 24;

            // Act
            dateTimeModel.IncrementTime();

            // Assert
            Assert.That(dateTimeModel.SimulationDate.Date, Is.EqualTo(DateTime.Now.AddDays(1).Date));
            Assert.That(dateTimeModel.SimulationTime, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void GetCurrentTime_ShouldReturnFormattedSimulationTime()
        {
            // Arrange
            var dateTimeModel = new DateTimeModel();
            dateTimeModel.SimulationTime = TimeSpan.FromHours(10);

            // Act
            var currentTime = dateTimeModel.GetCurrentTime();

            // Assert
            Assert.That(currentTime, Is.EqualTo("10:00:00"));
        }

        [Test]
        public void GetCurrentDate_ShouldReturnFormattedSimulationDate()
        {
            // Arrange
            var dateTimeModel = new DateTimeModel();
            dateTimeModel.SimulationDate = new DateTime(2022, 1, 1);

            // Act
            var currentDate = dateTimeModel.GetCurrentDate();

            // Assert
            Assert.That(currentDate, Is.EqualTo("January 1, 2022"));
        }
    }
}