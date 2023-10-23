namespace LaboratoryWork_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var arrayToSort = Enumerable.Range(0, 40).Select(index => random.Next(-10000, 10000)).ToArray();

            QuickSort.Sort(arrayToSort);

            Console.WriteLine(String.Join('\n', arrayToSort));
        }
    }
}