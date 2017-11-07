using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.AverageOfDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine();
            Console.WriteLine(numbers.Split(' ')
                .Select(double.Parse)
                .Average());
        }
    }
}
