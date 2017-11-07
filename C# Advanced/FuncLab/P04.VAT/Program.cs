using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:n2}"));


        }
    }
}
