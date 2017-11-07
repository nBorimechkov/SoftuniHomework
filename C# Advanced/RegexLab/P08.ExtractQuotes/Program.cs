using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P08.ExtractQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex("('|\")(.+?)\\1");
            MatchCollection matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[2].Value);
            }
            Console.ReadLine();
        }
    }
}

