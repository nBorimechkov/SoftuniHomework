using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(int.Parse(Console.ReadLine()));
            Console.ReadLine();
        }

        private static void Print(int n)
        {
            if (n <= 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            Print(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
