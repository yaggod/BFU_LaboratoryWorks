using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_11
{
    internal class QuickSort
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Sort(array, 0, array.Length - 1);
        }

        public static void Sort<T>(T[] array, int from, int to) where T : IComparable<T>
        {
            int middle = from + (to - from) / 2;
            T pivot = array[middle];

            int leftIndex = from;
            int rightIndex = to;

            while(leftIndex <= rightIndex)
            {
                while (array[leftIndex].CompareTo(pivot) < 0)
                    leftIndex++;
                while (array[rightIndex].CompareTo(pivot) > 0)
                    rightIndex--;

                if(leftIndex <= rightIndex)
                {
                    (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
                    leftIndex++;
                    rightIndex--;
                }


            }

        }
    }
}
