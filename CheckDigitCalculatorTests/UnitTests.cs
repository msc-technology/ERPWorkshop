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
            calc.CalculateChackDigit("MsCU995387");
        }
        public void throw_if_invalid_format_not_respecting_letters()
        {
            calc.CalculateChackDigit("1SCU995387");
        }
    }
}
