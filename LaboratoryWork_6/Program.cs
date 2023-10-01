namespace LaboratoryWork_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var arrayToSort = Enumerable.Range(0, 20).Select(index => random.Next(-10000, 10000)).ToArray();

            SelectionSort.Sort(arrayToSort);


            Console.WriteLine(String.Join('\n', arrayToSort));
        }
    }
}