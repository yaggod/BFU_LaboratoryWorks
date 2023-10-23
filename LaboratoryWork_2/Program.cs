using System.Threading.Channels;

namespace LaboratoryWork_2
{
    internal class Program
    {
        private const string validExpression = "(1 + (2 * (3 / 5)) - 2 * 7 - 2 / 9) * (1 * (35 * (-215 / 234)))=";
        private const string firstInvalidExpression = "((1 + 2 * 3 / 5 - 2 * 7 - 2 / 9) * (1 * 35 * (-215 / 234))=";
        private const string secondInvalidExpression = "(1 + 2 * 3 / 5 - 2 * 7 - 2 / 9) * (1 * 35 * (-215 / 234)))=";
        private const string thirdInvalidExpression = "(1 + 2 * 3 / 5 - 2 * 7 - 2 / 9) * (1 * 35 * (-215 / 0)))=";
        static void Main(string[] args)
        {
            try
            {
                //   Console.WriteLine("Введите вашу строку: ");
                // string inputString = Console.ReadLine();

                string inputString = thirdInvalidExpression;


                ExpressionEvaluator evaluator = new(inputString);
                float result = evaluator.Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Формат строки неправильный");
            }
        }
    }
}