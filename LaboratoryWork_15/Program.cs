using BinaryTree;

namespace LaboratoryWork_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "8(3(1, 6(4, 7)), 10(, 14(13,)))";
            
            var tree = IntegerTreeParser.GetTreeFromString(expression);

            List<int> inorderTraverseList = tree.TraverseTree(TreeTraverseTypes.Inorder);
            List<int> postorderTraverseList = tree.TraverseTree(TreeTraverseTypes.Postorder);
            List<int> preorderTraverseList = tree.TraverseTree(TreeTraverseTypes.Preorder);

            Console.WriteLine("Центральный\t" + String.Join(' ', inorderTraverseList));
            Console.WriteLine("Концевой\t" + String.Join(' ', postorderTraverseList));
            Console.WriteLine("Прямой\t\t"  + String.Join(' ', preorderTraverseList));
        }
    }
}