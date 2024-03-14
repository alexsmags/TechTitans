using NUnit.Framework;
using Home_Simulator.Converters;
using System;
using System.Globalization;

namespace Home_Simulator.Tests.Converters
{
    [TestFixture]
    public class AndMultiValueConverterTests
    {
        private AndMultiValueConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new AndMultiValueConverter();
        }

        [Test]
        public void Convert_AllTrueValues_ReturnsTrue()
        {
            var values = new object[] { true, true, true };

            var result = _converter.Convert(values, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [Test]
        public void Convert_AnyFalseValue_ReturnsFalse()
        {
            var values = new object[] { true, false, true };

            var result = _converter.Convert(values, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [Test]
        public void Convert_NonBooleanValue_ReturnsFalse()
        {
            var values = new object[] { true, "not a bool", true };

            var result = _converter.Convert(values, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [Test]
        public void Convert_EmptyValues_ReturnsTrue()
        {
            var values = new object[] { };

            var result = _converter.Convert(values, typeof(bool), null, CultureInfo.InvariantCulture);

            // Interpretation may vary; here, no false value means true
            Assert.IsTrue((bool)result);
        }
    }
}
