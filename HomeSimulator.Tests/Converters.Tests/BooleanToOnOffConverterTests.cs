using NUnit.Framework;
using Home_Simulator.Converters;
using System;
using System.Globalization;

namespace Home_Simulator.Tests.Converters
{
    [TestFixture]
    public class BooleanToOnOffConverterTests
    {
        private BooleanToOnOffConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new BooleanToOnOffConverter();
        }

        [Test]
        public void Convert_WhenTrue_ReturnsOn()
        {
            var result = _converter.Convert(true, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("On", result);
        }

        [Test]
        public void Convert_WhenFalse_ReturnsOff()
        {
            var result = _converter.Convert(false, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("Off", result);
        }

        [Test]
        public void Convert_WhenNotBoolean_ReturnsOff()
        {
            var result = _converter.Convert(null, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual("Off", result);
        }

        [Test]
        public void ConvertBack_WhenOn_ReturnsTrue()
        {
            var result = _converter.ConvertBack("On", null, null, CultureInfo.InvariantCulture);
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void ConvertBack_WhenOff_ReturnsFalse()
        {
            var result = _converter.ConvertBack("Off", null, null, CultureInfo.InvariantCulture);
            Assert.IsFalse((bool)result);
        }

        [Test]
        public void ConvertBack_WhenRandomString_ReturnsFalse()
        {
            var result = _converter.ConvertBack("RandomString", null, null, CultureInfo.InvariantCulture);
            Assert.IsFalse((bool)result);
        }
    }
}
