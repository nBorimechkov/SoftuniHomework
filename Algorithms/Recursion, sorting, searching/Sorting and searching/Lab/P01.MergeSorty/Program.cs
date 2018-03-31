using System;

namespace P01.MergeSorty
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 4, 3, 2, 1 };
            MergeSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
            Console.ReadLine();
        }
    }
}
