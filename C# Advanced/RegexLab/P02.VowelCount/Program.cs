using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P02.VowelCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex("[AEOIUYaeoiuy]");
            int count = regex.Matches(text).Count;
            Console.WriteLine($"Vowels: {count}");
            
        }
    }
}
