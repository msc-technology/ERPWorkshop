using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerCheckDigitCalculator
{
    public interface IContainerCheckDigitCalculator
    {
        int CalculateChackDigit(string partialContainerCode);
    }
}
