using System;
using System.Linq;

namespace P01.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
            Console.ReadLine();
        }

        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Merge(int[] arr, int lo, int mid, int hi)
        {
            if (mid < 0
                || mid + 1 >= arr.Length
                || arr[mid] <= arr[mid + 1])
            {
                return;
            }

            int[] helpArr = new int[arr.Length];

            for (int i = lo; i <= hi; i++)
            {
                helpArr[i] = arr[i];
            }

            int left = lo;
            int right = mid + 1;

            for (int i = lo; i <= hi; i++)
            {
                if (left > mid)
                {
                    arr[i] = helpArr[right++];
                }
                else if (right > hi)
                {
                    arr[i] = helpArr[left++];
                }
                else if (helpArr[left] <= helpArr[right])
                {
                    arr[i] = helpArr[left++];
                }
                else if (helpArr[left] > helpArr[right])
                {
                    arr[i] = helpArr[right++];
                }
            }
        }

        private static void Sort(int[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int mid = (lo + hi) / 2;

            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }

        private static int[] Swap(int[] arr, int num1, int num2)
        {
            int temp = arr[num1];
            arr[num1] = arr[num2];
            arr[num2] = temp;

            return arr;
        }
    }
}
