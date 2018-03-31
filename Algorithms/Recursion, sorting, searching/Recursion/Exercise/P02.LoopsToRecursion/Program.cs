using System;

namespace P02.LoopsToRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Gen01(new int[size], 0, size);
            Console.ReadLine();
        }

        private static void Gen01(int[] vector, int index, int size)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            for (int i = 1; i <= size; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1, size);
            }
        }
    }
}
