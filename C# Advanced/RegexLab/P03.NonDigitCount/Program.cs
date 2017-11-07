using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.NonDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex("\\D");
            int count = regex.Matches(text).Count;
            Console.WriteLine($"Non-digits: {count}");
            Console.ReadLine();
        }
    }
}
