using NUnit.Framework;
using Home_Simulator.Components;
using System.Collections.Generic;
using System.Windows.Controls; // Required for accessing the ListBox control

namespace Home_Simulator.Tests
{
    [TestFixture]
    public class RoomListingTests
    {
        private RoomListing _roomListing;

        [SetUp]
        public void SetUp()
        {
            _roomListing = new RoomListing();
            // Assuming RoomListBox is accessible for this test to directly interact with
            _roomListing.RoomListBox = new ListBox();
        }

        [Test]
        public void PopulateRoomList_WithRoomNames_SetsItemsSourceCorrectly()
        {
            // Arrange
            var roomNames = new List<string> { "Living Room", "Kitchen", "Bedroom" };

            // Act
            _roomListing.PopulateRoomList(roomNames);

            // Assert
            Assert.AreEqual(roomNames, _roomListing.RoomListBox.ItemsSource);
        }
    }
}
