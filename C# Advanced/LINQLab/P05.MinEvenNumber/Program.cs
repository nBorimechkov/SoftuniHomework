using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.MinEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine();
            Console.WriteLine($"{numbers.Split(' ').Select(double.Parse).Where(n => n % 2 == 0).Min():f2}");
            Console.ReadLine();
        }
    }
}
