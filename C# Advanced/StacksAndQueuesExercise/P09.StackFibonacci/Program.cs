using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            long f1 = 0;
            long f2 = 1;
            long fib = 0;
            stack.Push(f1);
            stack.Push(f2);

            for (long i = 0; i < n - 1; i++)
            {
                fib = f1 + f2;
                f1 = f2;
                f2 = fib;
                stack.Push(fib);
            }

            Console.WriteLine(stack.Pop());
            Console.ReadLine();
        }
    }
}
