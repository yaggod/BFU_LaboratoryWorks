using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6
{
    internal class SelectionSort
    {
        public static void Sort<T>(T[] values) where T: IComparable<T>
        {
            for(int i = 0; i < values.Length; i++)
            {
                int minimalValueIndex = i;
                for(int j = i + 1; j < values.Length; j++)
                {
                    if (values[minimalValueIndex].CompareTo(values[j]) > 0)
                        minimalValueIndex = j;
                }

                T temp = values[i];
                values[i] = values[minimalValueIndex];
                values[minimalValueIndex] = temp;
            }
        }
    }
}
