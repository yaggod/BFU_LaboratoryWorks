using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8
{
    internal class RadixSort
    {
        private static readonly int SortingBase = 10;

        public static int[] GetSorted(int[] array)
        {
            int[] result = new int[array.Length];

            int[] positiveValues = array.Where(value => value >= 0).ToArray();
            int[] negativeValues = array.Where(value => value < 0).ToArray();

            int[] sortedPositive = GetSortedSignedArray(positiveValues, 1);
            int[] sortedNegative = GetSortedSignedArray(negativeValues, -1);

            for(int i = 0; i < sortedNegative.Length; i++)
            {
                result[i] = sortedNegative[sortedNegative.Length - 1 - i];
            }

            for(int i = 0; i < sortedPositive.Length; i++)
            {
                result[i + sortedNegative.Length] = sortedPositive[i];
            }

            return result;
        }

        private static int[] GetSortedSignedArray(int[] array, int sign = 1)
        {
            int[] result = array;
            int digitsCount = GetMaxDigitsCount(array, sign);
            for (int currentDigit = 0; currentDigit < digitsCount; currentDigit++)
            {
                result = GetSortedByCounting(result, currentDigit, sign);
            }

          
            return result;
        }
        private static int[] GetSortedByCounting(int[] array, int position, int sign = 1)
        {
            int[] result = new int[array.Length];

            int[] valuesCount = new int[SortingBase];
            foreach(int value in array)
            {
                int digit = GetDigitFromTheEnd(sign * value, position);
                valuesCount[digit]++;
            }

            for(int i = 1; i< valuesCount.Length; i++)
            {
                valuesCount[i] += valuesCount[i - 1];
            }
            
            for(int i = array.Length - 1; i >= 0; i--)
            {
                int element = array[i] * sign;
                int digit = GetDigitFromTheEnd(element, position);
                result[valuesCount[digit] - 1] = element * sign;
                valuesCount[digit]--;
            }



            return result;
        }


        private static int GetMaxDigitsCount(int[] array, int sign = 1)
        {
            int maxValue = 0;
            int digitsCount = 0;

            foreach (int value in array)
            {
                maxValue = Math.Max(maxValue, value * sign);
            }

            while (maxValue > 0)
            {
                digitsCount++;
                maxValue /= SortingBase;
            }

            return digitsCount;
        }

        private static int GetDigitFromTheEnd(int value, int position)
        {
            int powerOfBase = 1;
            for (; position > 0; position--)
                powerOfBase *= SortingBase;

            value /= powerOfBase;

            return GetMod(value, SortingBase);
        }

        private static int GetMod(int value, int modBase)
        {
            return (value % modBase + modBase) % modBase;
        }

    }
}
