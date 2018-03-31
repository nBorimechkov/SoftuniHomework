using System;
using System.Linq;

namespace P01.PermutationsNoRep
{
    class Program
    {
        static string[] elements = new string[0];
        static string[] set = new string[0];

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').ToArray();
            set = elements;
            Gen(0);
            Console.ReadLine();
        }

        public static void Gen(int index)
        {
            if (index >= set.Length)
                Console.WriteLine(string.Join(" ", set));
            else
                Gen(index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Gen(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            string temp = set[index];
            set[index] = set[i];
            set[i] = temp;
        }
    }
}
