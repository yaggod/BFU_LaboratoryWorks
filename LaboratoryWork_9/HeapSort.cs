using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9
{
    internal class HeapSort
    {
        public static T[] GetSorted<T>(T[] values) where T : IComparable<T>
        {
            List<T> result = new List<T>();
            if (values.Length > 0)
            {
                HeapNode<T> heap = new HeapNode<T>(values[0]);
                for (int i = 1; i < values.Length; i++)
                {
                    heap.AddValue(values[i]);
                }
                heap.FillListSorted(result);
            }

            return result.ToArray();
        }
    }
}
