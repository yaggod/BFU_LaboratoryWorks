using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_13
{
    internal class HashTable<T>
    {
        private readonly int _hashBase;
        private readonly Func<T, int> _hashFunction;
        private object[] _values;


        public HashTable(Func<T, int> hashFunction, int hashBase)
        {
            if (hashBase < 1)
                throw new ArgumentException(nameof(hashBase) + " can not be less than 1");

            _hashFunction = hashFunction;
            _hashBase = hashBase;

            _values = new object[hashBase];
        }

        public void Add(T item)
        {
            object objectToAdd = item as object;
            int hash = GetHashCode(item);

            int index = hash;
            while(_values[index] != null)
            {
                index++;
                if (index >= _values.Length)
                    ExpandArray();
            }
            _values[index] = objectToAdd;
        }

        private void ExpandArray()
        {
            object[] newValues = new object[_values.Length * 2];
            for(int i = 0; i < _values.Length; i++)
                newValues[i] = _values[i];

            _values = newValues;
        }

        public bool Contains(T item)
        {
            int hash = GetHashCode(item);
            for(int i = hash; i < _values.Length; i++)
            {
                if (_values[i].Equals(item))
                    return true;
            }

            return false;
        }

        public T[] GetValues()
        {
            return _values.Select(item => (T)item).ToArray();
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
