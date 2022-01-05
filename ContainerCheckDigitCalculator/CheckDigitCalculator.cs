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
        Dictionary<char, int> letters = new Dictionary<char, int>()
        { 
            {'A',10},{'B',12},{'C',13},{'D',14},
            {'E',15},{'F',16},{'G',17},{'H',18},
            {'I',19},{'J',20},{'K',21},{'L',23},
            {'M',24},{'N',25},{'O',26},{'P',27},
            {'Q',28},{'R',29},{'S',30},{'T',31},
            {'U',32},{'V',34},{'W',35},{'X',36},
            {'Y',37}, {'Z',38},

        };

        public int CalculateCheckDigit(string partialContainerCode)
        {
            EnsureCorrectFormat(partialContainerCode);
            int @base = 1;
            int result=0;
            for (int i = 0; i < partialContainerCode.Length; ++i)
            {
                if (char.IsLetter(partialContainerCode[i]))
                    result += @base * letters[partialContainerCode[i]];
                else
                    result += @base*int.Parse(partialContainerCode.Substring(i,1));
                @base *= 2;
            }
            double res = result / 11.0;
            int ires = (int)Math.Floor(res);
            var check = result - ires * 11;
            return check == 10 ? 0 : check;
         
        }

        private void EnsureCorrectFormat(string partialContainerCode)
        {
            if (!Regex.IsMatch(partialContainerCode, @"^[A-Z]{4}\d{6}$"))
                throw new ArgumentException("Invalid code format.");
        }
    }
}
