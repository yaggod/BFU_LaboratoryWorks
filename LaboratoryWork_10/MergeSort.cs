using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_10
{
    internal class MergeSort
    {
        public static T[] GetSorted<T>(T[] array) where T : IComparable<T>
        {
            return GetSorted(array, 0, array.Length - 1);
        }

        public static T[] GetSorted<T>(T[] array, int from, int to) where T : IComparable<T>
        {
            int middle = from + (to - from) / 2;
            if (from == to)
                return new T[] { array[from] };
            T[] leftPart = GetSorted(array, from, middle);
            T[] rightPlay = GetSorted(array, middle + 1, to);



            T[] newArray = new T[leftPart.Length + rightPlay.Length];

            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex + rightIndex < newArray.Length)
            {
                T minValue;
                if(!(leftIndex < leftPart.Length))
                {
                    minValue = rightPlay[rightIndex++];
                }
                else if(!(rightIndex < rightPlay.Length))
                {
                    minValue = leftPart[leftIndex++];
                }
                else
                {
                    T leftValue = leftPart[leftIndex];
                    T rightValue = rightPlay[rightIndex];
                    if (leftValue.CompareTo(rightValue) < 0)
                    {
                        minValue = leftValue;
                        leftIndex++;
                    }
                    else
                    {
                        minValue = rightValue;
                        rightIndex++;
                    }

                }
                newArray[leftIndex + rightIndex - 1] = minValue;

            }

            return newArray;
        }
    }
}
