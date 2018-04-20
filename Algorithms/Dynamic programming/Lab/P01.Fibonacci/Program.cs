using System;

namespace P01.Fibonacci
{
    class Program
    {
        static int Fib(int n, int[] arr)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (arr[n] != 0)
            {
                return arr[n];
            }

            var result = Fib(n - 1, arr) + Fib(n - 2, arr);

            arr[n] = result;

            return result;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Console.WriteLine(Fib(35, arr));
            Console.ReadLine();
        }
    }
}
