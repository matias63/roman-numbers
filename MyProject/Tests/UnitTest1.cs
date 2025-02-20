using NUnit.Framework;
using MyProject;

namespace MyProject.Tests
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [Test]
        [Description("Calculate number correctly")]
        public void TestToFloat_ValidRomanNumeral()
        {
            var romanNumeral = new RomanNumeral("IV");
            float result = romanNumeral.ToFloat();

            Assert.AreEqual(4.0f, result);
        }

        [Test]
        [Description("Throws Exception for too many identical numbers in a row")]
        public void TestToFloat_InvalidRomanNumeral_TooManyIdenticalNumbers()
        {
            Assert.Throws<ArgumentException>(() => new RomanNumeral("VIIII"));
        }

        [Test]
        [Description("Throws Exception for too many identical numbers before a bigger number")]
        public void TestToFloat_InvalidRomanNumeral_TooManyIdenticalNumbersBeforeBiggerNumber()
        {
            Assert.Throws<ArgumentException>(() => new RomanNumeral("IIV"));
        }
    }
}