using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P05.ExtractTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 

            while (input != "END")
            {
                Regex regex = new Regex("<.+?>");
                MatchCollection matches = regex.Matches(input);
                foreach (Match item in matches)
                {
                    Console.WriteLine(item);
                }

                input = Console.ReadLine();

            }          
            Console.ReadLine();
        }
    }
}
