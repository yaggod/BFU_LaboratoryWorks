using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7
{
    internal class ShellSort
    {
        public static void Sort<T>(T[] values) where T : IComparable<T>
        {
            for(int step = values.Length / 2; step > 0; step /= 2)
            {
                for(int i = step; i < values.Length; i++)
                {
                    T currentValue = values[i];
                    int j;

                    for(j = i - step; j >=0; j -= step)
                    {
                        if (currentValue.CompareTo(values[j]) > 0)
                        {
                            break;
                        }
                        values[j + step] = values[j];
                    }
                    values[j + step] = currentValue;
                }
            }
        }
    }
}


/*
for (int i = 1; i < values.Length; i++)
            {
                T currentValue = values[i];
                int j;
                for(j = i - 1; j >= 0; j--)
                {
                    if (currentValue.CompareTo(values[j]) > 0)
                    {
                        break;
                    }
                    values[j + 1] = values[j];
                }

                values[j+1] = currentValue;
                
            } 
*/