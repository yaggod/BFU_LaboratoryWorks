using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_5
{
    internal class InsertionSort
    {
        public static void Sort<T>(T[] values) where T : IComparable<T>
        {
            for (int i = 1; i < values.Length; i++)
            {
                T currentValue = values[i];
                int j;
                for(j = i - 1; j >= 0 && values[j].CompareTo(currentValue) > 0; j--)
                {
                    if (currentValue.CompareTo(values[j]) < 0)
                    {
                        values[j + 1] = values[j];
                    }
                }
                values[j+1] = currentValue;
                
            }
        }
    }
}
