using System;

namespace P02.QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 23, 13, 8, 48, 9 };
            QuickSort<int> sort = new QuickSort<int>();
            sort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
            Console.ReadLine();
        }
    }
}
