namespace LaboratoryWork_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var arrayToSort = Enumerable.Range(0, 100).Select(index => random.Next(-10000, 10000)).ToArray();

            int[] sortedArray = RadixSort.GetSorted(arrayToSort);

            Console.WriteLine(String.Join('\n', sortedArray));
        }
    }
}