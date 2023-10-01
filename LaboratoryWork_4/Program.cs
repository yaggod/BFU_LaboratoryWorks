namespace LaboratoryWork_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var arrayToSort = Enumerable.Range(0, 100).Select(index => random.Next() % 10000).ToArray();

            CombSort.Sort(arrayToSort);

            Console.WriteLine(String.Join('\n', arrayToSort));
        }
    }
}