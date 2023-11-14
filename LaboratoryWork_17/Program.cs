using BinaryTree;
using System.Runtime.CompilerServices;

namespace LaboratoryWork_17
{
    internal class Program
    {
        private static BinarySearchTreeNode<int>? _tree;
        static void Main(string[] args)
        {
            InitializeTree();
            EndlessLoop();

        }

        private static void InitializeTree()
        {
            string expression = "8(3(1, 6(4, 7)), 10(, 14(13,)))";
            var regularTree = IntegerTreeParser.GetTreeFromString(expression);
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
                object result = ExecuteUserTask(userInput);
                if (result != null)
                    Console.WriteLine(result);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("\n\n\n");


        }
        private static void ShowMenu()
        {
            Console.WriteLine("1: Add element");
            Console.WriteLine("2: Remove element");
            Console.WriteLine("3: Find element");
            Console.WriteLine("4: Exit");
        }

        private static object? ExecuteUserTask(string input)
        {
            try
            {
                var parameters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                int operationId = Int32.Parse(parameters[0]);
                int argument = Int32.Parse(parameters[1]); // TODO: fix exiting incorrect handling

                switch (operationId)
                {
                    case 1:
                         _tree?.Add(argument);
                        return null;
                    case 2:
                         _tree?.Remove(argument);
                        return null;
                    case 3:
                        BinarySearchTreeNode<int> foundSubtree = _tree.Find(argument);
                        return foundSubtree;
                    case 4:
                        return _tree;
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