using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04.ExtractInts
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex("\\d+");
            MatchCollection matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
