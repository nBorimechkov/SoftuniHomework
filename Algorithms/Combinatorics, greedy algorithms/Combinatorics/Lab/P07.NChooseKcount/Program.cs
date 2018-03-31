using System;

namespace P07.NChooseKcount
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n) / (Factorial(k) * Factorial(n - k)));
            Console.ReadLine();
        }

        static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return Factorial(n - 1) * n;
        }
    }
}
