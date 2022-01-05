using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContainerCheckDigitCalculator
{
    public class CheckDigitCalculator : IContainerCheckDigitCalculator
    {
        public int CalculateCheckDigit(string partialContainerCode)
        {
            EnsureCorrectFormat(partialContainerCode);
            return -1;
         
        }

        private void EnsureCorrectFormat(string partialContainerCode)
        {
            if (!Regex.IsMatch(partialContainerCode, @"^[A-Z]{4}\d{6}$"))
                throw new ArgumentException("Invalid code format.");
        }
    }
}
