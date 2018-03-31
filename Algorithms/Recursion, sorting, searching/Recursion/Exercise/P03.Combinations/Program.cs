using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<int[]> list = new List<int[]>();

            int[] set = new int[n];
            for (int i = 1; i <= set.Length; i++)
            {
                set[i - 1] = i;
            }
            Generate(set, new int[k], 0);
            Console.ReadLine();
        }

        private static void Generate(int[] set, int[] arr, int index)
        {
            if (index == arr.Length)
            { 
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    arr[index] = set[i];
                    Generate(set, arr, index + 1);
                }
                
            }
        }
    }
}
