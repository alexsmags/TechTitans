using NUnit.Framework;
using Home_Simulator.Models.HouseModels;
using System.Collections.ObjectModel;
using Home_Simulator.Models.ProfileModels;

namespace Home_Simulator.Tests.Models.HouseModels
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void AddUser_ShouldAddUserToUsersInRoom()
        {
            // Arrange
            Room room = new Room();
            User user = new("name", 1, UserType.Father);

            // Act
            room.AddUser(user);

            // Assert
            CollectionAssert.Contains(room.UsersInRoom, user);
        }

        [Test]
        public void RemoveUser_ShouldRemoveUserFromUsersInRoom()
        {
            // Arrange
            Room room = new Room();
            User user = new("name", 1, UserType.Father);

            room.AddUser(user);

            // Act
            room.RemoveUser(user);

            // Assert
            CollectionAssert.DoesNotContain(room.UsersInRoom, user);
        }
    }
}