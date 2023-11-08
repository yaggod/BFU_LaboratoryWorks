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

        public List<T> TraverseTree(TreeTraverseTypes traverseType)
        {
            List<T> result = new List<T>();
            switch (traverseType)
            {
                case TreeTraverseTypes.Preorder:
                    TraversePreorder(result);
                    break;
                case TreeTraverseTypes.Inorder:
                    TraverseInorder(result);
                    break;
                case TreeTraverseTypes.Postorder:
                    TraversePostorder(result);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return result;
        }

        private void TraversePreorder(List<T> destination)
        {
            destination.Add(Value);
            Left?.TraversePreorder(destination);
            Right?.TraversePreorder(destination);
        }

        private void TraverseInorder(List<T> destination)
        {
            Left?.TraverseInorder(destination);
            destination.Add(Value);
            Right?.TraverseInorder(destination);
        }

        private void TraversePostorder(List<T> destination)
        {
            Left?.TraversePostorder(destination);
            Right?.TraversePostorder(destination);
            destination.Add(Value);
        }


    }
}