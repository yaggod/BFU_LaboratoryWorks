using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9
{
    internal class HeapSort
    {
        public static void Sort<T>(T[] values) where T : IComparable<T>
        {
            int heapSize = values.Length;
            for(int i = heapSize / 2 - 1; i > 0; i--)
            {
                Heapify(values, heapSize, i);
            }

            for (int i = heapSize; i > 0; i--)
            {
                Heapify(values, i, 0);
                (values[i - 1], values[0]) = (values[0], values[i-1]);
            }
        }

        private static void Heapify<T>(T[] values, int heapSize, int currentIndex) where T : IComparable<T>
        {
            int largestValueIndex = currentIndex;

            int leftIndex = 2 * currentIndex + 1;
            int rightIndex = 2 * currentIndex + 2;

            if (leftIndex < heapSize && values[leftIndex].CompareTo(values[largestValueIndex]) > 0)
                largestValueIndex = leftIndex;


            if (rightIndex < heapSize && values[rightIndex].CompareTo(values[largestValueIndex]) > 0)
                largestValueIndex = rightIndex;

            if (largestValueIndex != currentIndex)
            {
                (values[largestValueIndex], values[currentIndex]) = (values[currentIndex], values[largestValueIndex]);    
                Heapify(values, heapSize, largestValueIndex);
            }
        }
    }
}
