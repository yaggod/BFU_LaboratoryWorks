namespace LaboratoryWork_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string expression = Console.ReadLine() ?? "";
            bool isValidExpression = ExpressionValidator.IsValidExpression(expression);
            Console.WriteLine("Введенная строка " + (isValidExpression ? "правильная" : "неправильная"));

            Console.ReadKey();
        }
    }
}