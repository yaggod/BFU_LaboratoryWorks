using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_3
{
    internal class ValueFinder

    {
        private static readonly long _firstPowerBase = 3;
        private static readonly long _secondPowerBase = 5;
        private static readonly long _thirdPowerBase = 7;
        public static List<long> GetSuitableNumbers(long maxValue)
        {
            List<long> result = new List<long>();
            long firstValue, secondValue, thirdValue;
            long production = 1;
            for (firstValue = 1; firstValue <= maxValue; firstValue *= _firstPowerBase)
                for(secondValue = 1; secondValue <= maxValue; secondValue *= _secondPowerBase)
                    for(thirdValue = 1;thirdValue <= maxValue; thirdValue *= _thirdPowerBase)
                    {
                        production = firstValue * secondValue * thirdValue;
                        if (production > maxValue)
                            break;
                        result.Add(production);
                    }

            return result;
        }
    }
}
