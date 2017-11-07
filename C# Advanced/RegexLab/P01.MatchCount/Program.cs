using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01.MatchCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            int count = regex.Matches(text).Count;
            Console.WriteLine(count);
        }
    }
}
