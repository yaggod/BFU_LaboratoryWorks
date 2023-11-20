using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_17
{
    internal class BinarySearchTreeNode<T> : BinaryTreeNode<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T>? _left;
        private BinaryTreeNode<T>? _right;

        private bool _isEmpty = false;
        public override BinaryTreeNode<T>? Left
        {
            get => _left;
            set
            {
                if (value != null && value.Value.CompareTo(this.Value) > 0)
                    throw new InvalidOperationException();
                _left = value;
            }
        }
        public override BinaryTreeNode<T>? Right
        {
            get => _right;
            set
            {
                if (value != null && value.Value.CompareTo(this.Value) < 0)
                    throw new InvalidOperationException();
                _right = value;
            }
        }

        public BinarySearchTreeNode(T item) : base(item)
        {

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

        public void Add(T item)
        {
            if (item.CompareTo(this.Value) < 0)
            {
                if (Left != null)
                    (Left as BinarySearchTreeNode<T>)?.Add(item);
                else
                    Left = new BinarySearchTreeNode<T>(item);
            }
            else
            {
                if (Right != null)
                    (Right as BinarySearchTreeNode<T>)?.Add(item);
                else
                    Right = new BinarySearchTreeNode<T>(item);
            }
        }

        public void Remove(T item)
        {
            if (this.Value.Equals(item))
            {
                RecalculateTree(this);
            }
            else
            {
                if (item.CompareTo(this.Value) < 0)
                    (Left as BinarySearchTreeNode<T>)?.Remove(item);
                else
                    (Right as BinarySearchTreeNode<T>)?.Remove(item);


                if ((Left as BinarySearchTreeNode<T>)?._isEmpty == true)
                    Left = null;
                if ((Right as BinarySearchTreeNode<T>)?._isEmpty == true)
                    Right = null;

            }

        }

        private static void RecalculateTree(BinarySearchTreeNode<T> node)
        {
            List<T> newElements = node.TraverseTree(TreeTraverseTypes.Preorder).ToList();
            newElements.RemoveAt(0);

            node.Left = null;
            node.Right = null;
            if(newElements.Count == 0)
            {
                node._isEmpty = true;
                return;
            }

            node.Value = newElements.ElementAt(0);
            for (int i = 1; i < newElements.Count(); i++)
                node.Add(newElements.ElementAt(i));

        }

        public BinarySearchTreeNode<T>? Find(T item)
        {
            if (this.Value.Equals(item))
                return this;

            if (item.CompareTo(this.Value) < 0)
                return (Left as BinarySearchTreeNode<T>)?.Find(item);
            else
                return (Right as BinarySearchTreeNode<T>)?.Find(item);

        }
    }
}
