using NUnit.Framework;
using Home_Simulator.Converters;
using System;
using System.Globalization;

namespace Home_Simulator.Tests.Converters
{
    [TestFixture]
    public class InverseBooleanConverterTests
    {
        private InverseBooleanConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new InverseBooleanConverter();
        }

        [TestCase(true, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = true)]
        public bool Convert_BooleanValue_ReturnsInvertedValue(bool input)
        {
            return (bool)_converter.Convert(input, null, null, CultureInfo.InvariantCulture);
        }

        [TestCase(true, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = true)]
        public bool ConvertBack_BooleanValue_ReturnsInvertedValue(bool input)
        {
            return (bool)_converter.ConvertBack(input, null, null, CultureInfo.InvariantCulture);
        }

        [Test]
        public void Convert_NonBooleanValue_ReturnsOriginalValue()
        {
            var nonBooleanValue = "test";
            var result = _converter.Convert(nonBooleanValue, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual(nonBooleanValue, result);
        }

        [Test]
        public void ConvertBack_NonBooleanValue_ReturnsOriginalValue()
        {
            var nonBooleanValue = "test";
            var result = _converter.ConvertBack(nonBooleanValue, null, null, CultureInfo.InvariantCulture);
            Assert.AreEqual(nonBooleanValue, result);
        }
    }
}
