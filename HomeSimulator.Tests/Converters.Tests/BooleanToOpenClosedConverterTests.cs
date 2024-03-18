using NUnit.Framework;
using Home_Simulator.Converters;
using System;
using System.Globalization;

namespace Home_Simulator.Tests.Converters
{
    [TestFixture]
    public class BooleanToOpenClosedConverterTests
    {
        private BooleanToOpenClosedConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new BooleanToOpenClosedConverter();
        }

        [Test]
        public void Convert_WhenTrue_ReturnsOpen()
        {
            var result = _converter.Convert(true, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("Open", result);
        }

        [Test]
        public void Convert_WhenFalse_ReturnsClosed()
        {
            var result = _converter.Convert(false, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("Closed", result);
        }

        [Test]
        public void Convert_WhenNotBoolean_ReturnsClosed()
        {
            // Testing with null as a common non-boolean value
            var result = _converter.Convert(null, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("Closed", result);
        }

        [Test]
        public void ConvertBack_WhenOpen_ReturnsTrue()
        {
            var result = _converter.ConvertBack("Open", null, null, CultureInfo.InvariantCulture);
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void ConvertBack_WhenNotOpen_ReturnsFalse()
        {
            // Testing with "Closed" and a random string to ensure only "Open" returns true
            var resultClosed = _converter.ConvertBack("Closed", null, null, CultureInfo.InvariantCulture);
            var resultRandomString = _converter.ConvertBack("RandomString", null, null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)resultClosed);
            Assert.IsFalse((bool)resultRandomString);
        }
    }
}
