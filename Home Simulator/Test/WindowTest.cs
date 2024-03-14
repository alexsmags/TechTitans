using Home_Simulator.Models.HouseModels;

namespace Test
{
    [TestFixture]
    public class WindowTest
    {
        [Test]
        public void TestOpenWindow()
        {
            // Arrange
            Window window = new Window();

            // Act
            window.OpenWindow();

            // Assert
            Assert.IsTrue(window.IsOpen);
            Assert.AreEqual(@"\..\..\Images\HouseObjectIcons\window_open.png", window.WindowImage.UriSource.OriginalString);
        }

        [Test]
        public void TestCloseWindow()
        {
            // Arrange
            Window window = new Window();

            // Act
            window.CloseWindow();

            // Assert
            Assert.IsFalse(window.IsOpen);
            Assert.AreEqual(@"\..\..\Images\HouseObjectIcons\window_closed.png", window.WindowImage.UriSource.OriginalString);
        }

        [Test]
        public void TestBlockWindow()
        {
            // Arrange
            Window window = new Window();

            // Act
            window.BlockWindow();

            // Assert
            Assert.IsTrue(window.IsBlocked);
            Assert.AreEqual(@"\..\..\Images\HouseObjectIcons\blocked_icon.png", window.WindowImage.UriSource.OriginalString);
        }

        [Test]
        public void TestUnBlockWindow()
        {
            // Arrange
            Window window = new Window();
            window.BlockWindow();

            // Act
            window.UnBlockWindow();

            // Assert
            Assert.IsFalse(window.IsBlocked);
            Assert.AreEqual(@"\..\..\Images\HouseObjectIcons\window_closed.png", window.WindowImage.UriSource.OriginalString);
        }
    }
}