using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Console.Write($"Sum={numbers.Sum():0}; ");
            Console.Write($"Average={numbers.Average():0.00}");
            Console.ReadLine();
        }
    }
}
