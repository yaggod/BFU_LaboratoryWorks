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
            throw new NotImplementedException();
        }
    }
}
