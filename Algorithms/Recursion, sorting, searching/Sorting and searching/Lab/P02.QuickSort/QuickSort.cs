using System;
using System.Collections.Generic;
using System.Text;

namespace P02.QuickSort
{
    class QuickSort<T> where T : IComparable
    {
        public void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }
        private void Sort(T[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int pi = Partition(arr, lo, hi);
                Sort(arr, lo, pi - 1);
                Sort(arr, pi + 1, hi);
            }
        }

        private int Partition(T[] arr, int lo, int hi)
        {
            T pivot = arr[hi];
            int i = lo - 1;

            for (int j = lo; j <= hi - 1; j++)
            {
                if (Less(arr[j], pivot))
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, hi);
            return i + 1;
        }

        private bool Less(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }
        private void Swap(T[] arr, int first, int second)
        {
            T temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
