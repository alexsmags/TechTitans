using Moq;
using NUnit.Framework;
using Home_Simulator.Commands;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using Home_Simulator.ProfileReader;
using System.Collections.Generic;

namespace Home_Simulator.Tests.Commands
{
    [TestFixture]
    public class AddUserCommandTests
    {
        private Mock<SimulationViewModel> _mockSimulationViewModel;
        private Mock<IProfileReaderService> _mockProfileReaderService; // Assuming ProfileReaderService implements IProfileReaderService

        [SetUp]
        public void SetUp()
        {
            _mockSimulationViewModel = new Mock<SimulationViewModel>();
            _mockSimulationViewModel.Setup(vm => vm.users).Returns(new List<User>());

            // Assuming ProfileReaderService has been refactored to use IProfileReaderService for DI
            _mockProfileReaderService = new Mock<IProfileReaderService>();
            ProfileReaderService.Instance = _mockProfileReaderService.Object; // This setup is conceptual
        }

        [Test]
        public void Execute_UserAdded_UpdatesSimulationViewModelAndProfileReaderService()
        {
            // Arrange
            var addUserCommand = new AddUserCommand(_mockSimulationViewModel.Object);
            // Assuming we can mock dialog interactions
            MockAddUserDialogToReturnValidUser();

            // Act
            addUserCommand.Execute(null);

            // Assert
            _mockSimulationViewModel.Verify(vm => vm.users.Add(It.IsAny<User>()), Times.Once);
            _mockProfileReaderService.Verify(prs => prs.AddUser(It.IsAny<User>()), Times.Once);
        }
    }
}
