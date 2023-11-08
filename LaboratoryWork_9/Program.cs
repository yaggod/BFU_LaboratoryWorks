﻿namespace LaboratoryWork_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var arrayToSort = Enumerable.Range(0, 20).Select(index => random.Next(-10000, 10000)).ToArray();

            HeapSort.Sort(arrayToSort);

            Console.WriteLine(String.Join('\n', arrayToSort));


        }
    }
}