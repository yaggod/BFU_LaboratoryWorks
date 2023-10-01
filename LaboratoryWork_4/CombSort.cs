using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_4
{
    internal class CombSort
    {
        public static void Sort<T>(T[] values, double factor = 1.2473309) where T : IComparable<T>
        {
            int step = values.Length;

            while(step > 1)
            {
                step = (int)(step / factor);
                if (step < 1)
                    step = 1;
                int i = 0, j = step;

                while (j < values.Length) 
                {
                    if (values[i].CompareTo(values[j]) > 0)
                    {
                        (values[j], values[i]) = (values[i], values[j]);
                    }
                    i++;
                    j = i + step;
                }

            }
        }
    }
}
