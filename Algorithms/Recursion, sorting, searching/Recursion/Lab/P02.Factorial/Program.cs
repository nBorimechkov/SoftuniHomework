using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
            Console.ReadLine();
        }

        private static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else return n * Factorial(n - 1);
        }
    }
}
