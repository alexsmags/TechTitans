using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using System.IO;
using Home_Simulator.ViewModels;
using Home_Simulator.Commands;

namespace Home_Simulator.UnitTests
{
    [TestFixture]
    public class LoadCSVTemperatureCommandTest
    {
        [Test]
        public void Execute_ValidCSVFile_LoadsTemperatureData()
        {
            // Arrange
            var mockSimulationViewModel = new Mock<SimulationViewModel>();
            var command = new LoadCSVTemperatureCommand(mockSimulationViewModel.Object);

            // Create a temporary CSV file with valid data
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "DateTime, Temperature\n2024-01-01 00:00, 25.0\n2024-01-01 01:00, 26.0");

            // Act
            command.Execute(tempFilePath);

            // Assert
            mockSimulationViewModel.VerifySet(vm => vm.OutsideTemperatureData = It.IsAny<List<(DateTime, double)>>(), Times.Once);
            // Assert any other expectations, such as message box displays
            // Cleanup
            File.Delete(tempFilePath);
        }

        [Test]
        public void Execute_MissingFile_ShowsErrorMessage()
        {
            // Arrange
            var mockSimulationViewModel = new Mock<SimulationViewModel>();
            var command = new LoadCSVTemperatureCommand(mockSimulationViewModel.Object);

            // Act
            command.Execute("nonexistent_file.csv");

            // Assert
            // Verify that an error message box is shown
            // Assert any other expectations
        }

        [Test]
        public void Execute_InvalidData_ShowsErrorMessage()
        {
            // Arrange
            var mockSimulationViewModel = new Mock<SimulationViewModel>();
            var command = new LoadCSVTemperatureCommand(mockSimulationViewModel.Object);

            // Create a temporary CSV file with invalid data
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "InvalidData");

            // Act
            command.Execute(tempFilePath);

            // Assert
            // Verify that an error message box is shown
            // Assert any other expectations
            // Cleanup
            File.Delete(tempFilePath);
        }
    }
}
