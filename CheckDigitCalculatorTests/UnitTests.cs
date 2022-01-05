using System;
using ContainerCheckDigitCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckDigitCalculatorTests
{
    [TestClass]
    public class UnitTests
    {
        IContainerCheckDigitCalculator calc;
        [TestInitialize]
        public void Init()
        {
            calc = new CheckDigitCalculator();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Invalid code format.")]
        public void throw_if_invalid_format_not_proper_case()
        {
            calc.CalculateCheckDigit("MsCU995387");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid code format.")]
        public void throw_if_invalid_format_not_respecting_letters()
        {
            calc.CalculateCheckDigit("1SCU995387");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid code format.")]
        public void throw_if_invalid_format_too_many_letters()
        {
            calc.CalculateCheckDigit("MSCUU995387");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid code format.")]
        public void throw_if_invalid_format_too_many_digits()
        {
            calc.CalculateCheckDigit("MSC1995387");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid code format.")]
        public void throw_if_invalid_format_too_short()
        {
            calc.CalculateCheckDigit("MSC199537");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid code format.")]
        public void throw_if_invalid_format_too_long()
        {
            calc.CalculateCheckDigit("MSC1995376");
        }
        
        [TestMethod]
        public void check_digit_must_be_zero()
        {
            Assert.IsTrue(0 == calc.CalculateCheckDigit("MSCU620157"));
        }
        [TestMethod]
        public void check_digit_must_be_1()
        {
            Assert.IsTrue(1 == calc.CalculateCheckDigit("MSCU620159"));
        }
        [TestMethod]
        public void check_digit_must_be_2()
        {
            Assert.IsTrue(2 == calc.CalculateCheckDigit("MSCU344521"));
        }
        [TestMethod]
        public void check_digit_must_be_3()
        {
            Assert.IsTrue(3 == calc.CalculateCheckDigit("MSCU620152"));
        }
        [TestMethod]
        public void check_digit_must_be_4()
        {
            Assert.IsTrue(4 == calc.CalculateCheckDigit("MSCU620154"));
        }
        [TestMethod]
        public void check_digit_must_be_5()
        {
            Assert.IsTrue(5 == calc.CalculateCheckDigit("MSCU620156"));
        }
        [TestMethod]
        public void check_digit_must_be_6()
        {
            Assert.IsTrue(6 == calc.CalculateCheckDigit("MSCU620158"));
        }
        [TestMethod]
        public void check_digit_must_be_7()
        {
            Assert.IsTrue(7 == calc.CalculateCheckDigit("MSCU781613"));
        }
        [TestMethod]
        public void check_digit_must_be_8()
        {
            Assert.IsTrue(8 == calc.CalculateCheckDigit("MSCU344518"));
        }
        [TestMethod]
        public void check_digit_must_be_9()
        {
            Assert.IsTrue(9 == calc.CalculateCheckDigit("MSCU620153"));
        }
    }
}
