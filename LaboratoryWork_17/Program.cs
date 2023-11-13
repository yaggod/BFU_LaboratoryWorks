using BinaryTree;

namespace LaboratoryWork_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "8(9(1, 6(4, 7)), 10(, 14(13,)))";
            var regularTree = IntegerTreeParser.GetTreeFromString(expression);
            var binarySearchTree = BinarySearchTreeNode<int>.FromBinaryTree(regularTree);
        }
    }
}