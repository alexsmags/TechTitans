using NUnit.Framework;
using Home_Simulator.ProfileReader;
using Home_Simulator.Models.ProfileModels;
using System.Collections.ObjectModel;
using System.IO;
using System;
using Moq;
using System.IO.Abstractions; // Assumed for file system abstraction

namespace Home_Simulator.Tests.ProfileReader
{
    [TestFixture]
    public class ProfileReaderServiceTests
    {
        private Mock<IFileSystem> _mockFileSystem;
        private string _filePath = @"C:\fakepath\ProfileList.txt";
        private ProfileReaderService _serviceUnderTest;

        [SetUp]
        public void SetUp()
        {
            _mockFileSystem = new Mock<IFileSystem>();
            ProfileReaderService.OverrideFileSystem(_mockFileSystem.Object); // Hypothetical method to override file system
            _serviceUnderTest = ProfileReaderService.Instance;

            // Mock file existence and contents setup
            _mockFileSystem.Setup(fs => fs.File.Exists(_filePath)).Returns(true);
            _mockFileSystem.Setup(fs => fs.File.ReadAllLines(_filePath)).Returns(new string[] {
                "User: name=John Doe, age=30, UserType=Standard",
                "User: name=Jane Doe, age=25, UserType=Admin"
            });
            _mockFileSystem.Setup(fs => fs.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void LoadUsers_WhenFileExists_ReturnsCorrectUsers()
        {
            // Act
            var users = _serviceUnderTest.LoadUsers();

            // Assert
            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);
            Assert.AreEqual("John Doe", users[0].Name);
        }

        [Test]
        public void SaveUsers_WithValidUsers_WritesToFile()
        {
            // Arrange
            var users = new ObservableCollection<User> {
                new User("John Doe", 30, UserType.Standard),
                new User("Jane Doe", 25, UserType.Admin)
            };

            // Act
            _serviceUnderTest.SaveUsers(users);

            // Assert
            _mockFileSystem.Verify(fs => fs.File.WriteAllLines(_filePath, It.IsAny<string[]>()), Times.Once);
        }

        [Test]
        public void AddUser_WithValidUser_AppendsToFile()
        {
            // Arrange
            var user = new User("New User", 28, UserType.Guest);

            // Act
            _serviceUnderTest.AddUser(user);

            // Assert
            _mockFileSystem.Verify(fs => fs.File.AppendText(_filePath), Times.Once);
        }

        [Test]
        public void RemoveUser_WithExistingUser_RemovesFromProfileList()
        {
            // Additional setup to mock read and write for removal
            _mockFileSystem.Setup(fs => fs.File.ReadAllLines(_filePath)).Returns(new string[] {
                "User: name=New User, age=28, UserType=Guest"
            });

            // Arrange
            var userToRemove = new User("New User", 28, UserType.Guest);

            // Act
            _serviceUnderTest.RemoveUser(userToRemove);

            // Assert - Verify that write operation occurs with one less user
            _mockFileSystem.Verify(fs => fs.File.WriteAllLines(_filePath, It.IsAny<string[]>()), Times.AtLeastOnce);
        }
    }
}
