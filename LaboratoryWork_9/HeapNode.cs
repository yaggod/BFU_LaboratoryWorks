using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9
{
    internal class HeapNode<T> where T: IComparable<T>
    {
        public HeapNode<T> Left
        {
            get; 
            set;
        }

        public HeapNode<T> Right
        {
            get; 
            set;
        }

        public T Value
        {
            get; 
            set;
        }


        public HeapNode(T value)
        {
            Value = value;
        }

        public void AddValue(T value)
        {
            if(Value.CompareTo(value) > 0)
            {
                if (Left != null)
                    Left.AddValue(value);
                else
                    Left = new HeapNode<T>(value);
            }

            else
            {
                if (Right != null)
                    Right.AddValue(value);
                else
                    Right = new HeapNode<T>(value);
            }
        }

        public void FillListSorted(List<T> destination)
        {
            if (Left == null)
                destination.Add(Value);
            else
            {
                Left.FillListSorted(destination);
            }
            if (Right != null)
            {
                Right.FillListSorted(destination);
            }
        }
    }
}
