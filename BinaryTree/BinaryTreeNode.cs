namespace BinaryTree
{
    public class BinaryTreeNode<T>
    {
        public T Value
        {
            get; 
            set;
        }
        public BinaryTreeNode<T>? Left
        {
            get;
            set;
        }
        public BinaryTreeNode<T>? Right
        {
            get;
            set;
        }

        public BinaryTreeNode(T item)
        {
            Value = item;
        }

        

    }
}