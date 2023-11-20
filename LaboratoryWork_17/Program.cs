using BinaryTree;
using System.Runtime.CompilerServices;

namespace LaboratoryWork_17
{
    internal class Program
    {
        private const string ExampleTreeExpression = "8(3(1, 6(4, 7)), 10(, 14(13,)))";
        private static BinarySearchTreeNode<int>? _tree;
        static void Main(string[] args)
        {
            InitializeTree();
            EndlessLoop();

        }

        private static void InitializeTree()
        {
            Console.WriteLine("Input your tree: ");
            string treeExpression = ExampleTreeExpression;//Console.ReadLine() ?? "";
            var regularTree = IntegerTreeParser.GetTreeFromString(treeExpression);
            _tree = BinarySearchTreeNode<int>.FromBinaryTree(regularTree);


        }


        private static void EndlessLoop()
        {
            while(true)
            {
                EndlessLoopIterate();
            }
        }

        private static void EndlessLoopIterate()
        {
            ShowMenu();
            string userInput = Console.ReadLine();
            try
            {
                BinarySearchTreeNode<int> result = ExecuteUserTask(userInput);
                if (result != null)
                    Console.WriteLine("\t" + result);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("\n\n\n");


        }
        private static void ShowMenu()
        {
            Console.WriteLine("1 [V]: Add element");
            Console.WriteLine("2 [V]: Remove element");
            Console.WriteLine("3 [V]: Find element");
        }

        private static BinarySearchTreeNode<int>? ExecuteUserTask(string input)
        {
            try
            {
                var parameters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                int operationId = Int32.Parse(parameters[0]);


                int argument = Int32.Parse(parameters[1]);

                switch (operationId)
                {
                    case 1:
                         _tree?.Add(argument);
                        return _tree;
                    case 2:
                         _tree?.Remove(argument);
                        return _tree;
                    case 3:
                        BinarySearchTreeNode<int>? foundSubtree = _tree?.Find(argument);
                        return foundSubtree;
                    default:
                        throw new InvalidOperationException($"{nameof(operationId)} can not be {operationId}");
                }
            }
            catch
            {
                throw new FormatException($"{nameof(input)} was not in correct format");
            }
        }
    }
}