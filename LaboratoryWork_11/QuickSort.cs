using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LaboratoryWork_11
{
    internal class QuickSort
    {
        public static void Sort<T>(T[] values) where T : IComparable<T>
        {
            Sort(values, 0, values.Length - 1);
        }

        public static void Sort<T>(T[] values, int from, int to) where T : IComparable<T>
        {
            if(from >= to)
            {
                return;
            }



            int pivotIndex = (from + to) / 2;
            T pivot = values[pivotIndex];


            int leftIndex = from;
            int rightIndex = to;

            while(leftIndex < rightIndex)
            {
                while (values[leftIndex].CompareTo(pivot) < 0)
                    leftIndex++;
                while (values[rightIndex].CompareTo(pivot) > 0)
                    rightIndex--;

                if(leftIndex <= rightIndex)
                {
                    (values[leftIndex], values[rightIndex]) = (values[rightIndex], values[leftIndex]);
                    leftIndex++;
                    rightIndex--;
                }
            }

            Sort(values, from, rightIndex);
            Sort(values, leftIndex, to);
        }
    }
}
