using Home_Simulator.Commands;
using Home_Simulator.Models.HouseModels;
using Home_Simulator.Stores;
using Home_Simulator.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.IO.Abstractions; // Assuming use of System.IO.Abstractions for mocking file system interactions

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class LoadHouseLayoutStartCommandTests
    {
        private Mock<INavigationStore> _mockNavigationStore;
        private Mock<IProfileReaderService> _mockProfileReaderService;
        private Mock<IFileDialogService> _mockFileDialogService; // Custom abstraction over OpenFileDialog
        private Mock<IFileSystem> _mockFileSystem; // Provided by System.IO.Abstractions for mocking file system access
        private LoadHouseLayoutStartCommand _command;

        [SetUp]
        public void SetUp()
        {
            _mockNavigationStore = new Mock<INavigationStore>();
            _mockProfileReaderService = new Mock<IProfileReaderService>();
            _mockFileDialogService = new Mock<IFileDialogService>();
            _mockFileSystem = new Mock<IFileSystem>();

            // Setup mocks as needed, e.g., simulate dialog result, file content, etc.
            _mockFileDialogService.Setup(m => m.ShowDialog()).Returns(true);
            _mockFileDialogService.Setup(m => m.FileName).Returns("house_layout.txt");
            _mockFileSystem.Setup(fs => fs.File.ReadAllText(It.IsAny<string>())).Returns("Sample file content");

            ProfileReaderService.Instance = _mockProfileReaderService.Object; // Assuming a way to set mock instance
            _command = new LoadHouseLayoutStartCommand(_mockNavigationStore.Object, _mockFileDialogService.Object, _mockFileSystem.Object);
        }

        [Test]
        public void Execute_WhenFileDialogConfirmed_UpdatesNavigationStoreWithSimulationViewModel()
        {
            // Act
            _command.Execute(null);

            // Assert
            _mockNavigationStore.VerifySet(ns => ns.CurrentViewModel = It.IsAny<SimulationViewModel>(), Times.Once);
        }


    }
}
