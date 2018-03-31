using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Sorting
{
    class BubbleSort
    {
        public static void Sort(int[] arr)
        { 
            for (int j = arr.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        arr = Swap(arr, i, i + 1);
                    }
                }
            }
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
