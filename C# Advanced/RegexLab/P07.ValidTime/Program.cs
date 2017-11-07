using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P07.ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                Regex regex = new Regex("^[00-11]+:[00-59]+:[00-59]+ (AM|PM)$");
                Match match = regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();

            }
            Console.ReadLine();
        }
    }
}
