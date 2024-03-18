using NUnit.Framework;
using Home_Simulator.Converters;
using System;
using System.Globalization;

namespace Home_Simulator.Tests.Converters
{
    [TestFixture]
    public class NullToBoolConverterTests
    {
        private NullToBoolConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new NullToBoolConverter();
        }

        [Test]
        public void Convert_WithNonNullValue_ReturnsTrue()
        {
            var nonNullValue = new object();
            var result = _converter.Convert(nonNullValue, typeof(bool), null, CultureInfo.InvariantCulture);
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void Convert_WithNullValue_ReturnsFalse()
        {
            object nullValue = null;
            var result = _converter.Convert(nullValue, typeof(bool), null, CultureInfo.InvariantCulture);
            Assert.IsFalse((bool)result);
        }

        [Test]
        public void ConvertBack_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                _converter.ConvertBack(null, typeof(object), null, CultureInfo.InvariantCulture));
        }
    }
}
