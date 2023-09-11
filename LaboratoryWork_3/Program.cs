namespace LaboratoryWork_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное число: ");
            long maxValue = Int64.Parse(Console.ReadLine() ?? "0");

            List<long> suitableValues = ValueFinder.GetSuitableNumbers(maxValue);
            suitableValues.Sort();
            Console.WriteLine(String.Join('\n', suitableValues));
        }
    }
}