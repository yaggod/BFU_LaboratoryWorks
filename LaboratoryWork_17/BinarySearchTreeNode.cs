using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_17
{
    internal class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T>? _left;
        private BinarySearchTreeNode<T>? _right;

        public T Value
        {
            get;
            set;
        }
        public BinarySearchTreeNode<T>? Left
        {
            get => _left;
            private set
            {
                if (value != null && value.Value.CompareTo(this.Value) > 0)
                    throw new InvalidOperationException();
                _left = value;
            }
        }
        public BinarySearchTreeNode<T>? Right
        {
            get => _right;
            private set
            {
                if (value != null && value.Value.CompareTo(this.Value) < 0)
                    throw new InvalidOperationException();
                _right = value;
            }
        }

        public BinarySearchTreeNode(T item)
        {
            Value = item;
        }

        public static BinarySearchTreeNode<T>? FromBinaryTree(BinaryTreeNode<T>? binaryTree)
        {
            if (binaryTree == null)
                return null;
            BinarySearchTreeNode<T> result = new(binaryTree.Value);
            result.Left = FromBinaryTree(binaryTree.Left);
            result.Right = FromBinaryTree(binaryTree.Right);

            return result;
        }
    }
}
