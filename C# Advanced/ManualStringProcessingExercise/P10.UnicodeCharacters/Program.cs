using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (var item in input)
            {
                Console.Write("\\u" + ((int)item).ToString("X4"));
            }
            Console.ReadLine();
        }
    }
}
