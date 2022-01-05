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
        [TestMethod]
        public void massive_test()
        {
            string[] probeset =
            {
                "MSDU4366030",
                "MSDU4366019",
                "GMCU3060960",
                "EXFU5611620",
                "EURU1540024",
                "EIAU2514095",
                "ANNU1726552",
                "ANNU8939288",
                "SEGU8130191",
                "RMCU0950404",
                "MSMU1356266",
                "MSMU1356250",
                "IHOU3051462",
                "SVLU2011036",
                "SVLU2011020",
                "OTPU6431393",
                "OTPU6431310",
                "OTPU6431290",
            };
            foreach (var code in probeset)
            {
                Assert.IsTrue(int.Parse(code.Substring(10, 1)) == calc.CalculateCheckDigit(code.Substring(0, 10)));
            }
        }
    }
}
