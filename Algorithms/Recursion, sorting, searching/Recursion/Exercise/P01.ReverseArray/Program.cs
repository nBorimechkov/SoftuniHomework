using System;
using System.Linq;

namespace P01.ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Reverse(arr, 0, arr.Length / 2, arr.Length - 1);
            Console.ReadLine();
        }

        static void Reverse(int[] arr, int index)
        {
            if (index < 0)
            {
                return;
            }
            Console.WriteLine(arr[index]);
            Reverse(arr, index - 1);
        }

        static void Reverse(int[] arr, int lo, int mid, int hi)
        {
            if (lo > mid || hi < mid)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            int temp = arr[lo];
            arr[lo] = arr[hi];
            arr[hi] = temp;
            lo++;
            hi--;
            Reverse(arr, lo, mid, hi);
        }
    }
}
