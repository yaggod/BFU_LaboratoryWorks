using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LaboratoryWork_14
{
    internal class HashTable<T>
    {
        private readonly int _hashBase;
        private readonly Func<T, int> _hashFunction;
        private readonly List<T>[] _values;

        public HashTable(Func<T,int> hashFunction, int hashBase)
        {
            if (hashBase < 1)
                throw new ArgumentException(nameof(hashBase) + " can not be less than 1");

            _hashBase = hashBase;
            _hashFunction = hashFunction;
            _values = new List<T>[_hashBase];

            for(int i = 0; i < _hashBase; i++)
            {
                _values[i] = new();
            }
        }

        public void Add(T item)
        {
            int hash = GetHashCode(item);
            _values[hash].Add(item);
        }

        public bool Contains(T item) 
        {
            int hash = GetHashCode(item);
            List<T> possibleLocation = _values[hash];
            foreach(T element in possibleLocation)
            {
                if (element.Equals(item))
                    return true;
            }

            return false;   
        }

        public List<T>? GetElementsWithHash(int hash)
        {
            List<T>? result = null;
            try
            {
                result = _values[hash];
            }
            catch { }

            return result;
        }

        private int GetHashCode(T item)
        {
            return Mod(_hashFunction(item), _hashBase);
        }

        private static int Mod(int value, int hashBase)
        {
            return (value % hashBase + hashBase) % hashBase;
        }
    }
}
