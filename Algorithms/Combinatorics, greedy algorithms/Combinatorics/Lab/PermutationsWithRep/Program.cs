using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsWithRep
{
    class Program
    {


        static void Main(string[] args)
        {

            string[] elements = Console.ReadLine().Split(' ').ToArray();
            string[] set = elements;
            PermuteRep(set, 0 , set.Length - 1);
            Console.ReadLine();

            void PermuteRep(string[] arr, int start, int end)
            {
                Print(arr);
                for (int left = end - 1; left >= start; left--)
                {
                    for (int right = left + 1; right <= end; right++)
                        if (arr[left] != arr[right])
                        {
                            Swap(left, right);
                            PermuteRep(arr, left + 1, end);
                        }
                    var firstElement = arr[left];
                    for (int i = left; i <= end - 1; i++)
                        arr[i] = arr[i + 1];
                    arr[end] = firstElement;
                }
            }

            void Print(string[] arr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }

             void Swap(int index, int i)
            {
                string temp = elements[index];
                elements[index] = elements[i];
                elements[i] = temp;
            }
        }


       

    }
}
