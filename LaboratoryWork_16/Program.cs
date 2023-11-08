using BinaryTree;

namespace LaboratoryWork_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "8(3(1, 6(4, 7)), 10(, 14(13,)))";
            var tree = IntegerTreeParser.GetTreeFromString(expression);

            List<int> result = tree.NonrecursiveTraverse();

            Console.WriteLine(String.Join(' ', result));
        }
    }
}