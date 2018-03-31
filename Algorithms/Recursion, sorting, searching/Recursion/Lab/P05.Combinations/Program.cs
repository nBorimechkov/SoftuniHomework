using System;
using System.Linq;

namespace P05.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = numbers[numbers.Length - 1];
            int k = int.Parse(Console.ReadLine());

            int[] set = new int[n];
            for (int i = 1; i <= set.Length; i++)
            {
                set[i - 1] = i;
            }
            Generate(set, new int[k], 0, 0);
            Console.ReadLine();
        }

        private static void Generate(int[] set, int[] arr, int index, int border)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    arr[index] = set[i];
                    Generate(set, arr, index + 1, i + 1);
                }
            }
        }
    }
}
