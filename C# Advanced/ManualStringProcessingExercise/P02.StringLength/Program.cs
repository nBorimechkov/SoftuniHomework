using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.StringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.Length > 20)
            {
                Console.WriteLine(input.Substring(0, 20));
            }
            else
            {
                for (int i = 0; i < 20 - input.Length; i++)
                {
                    input += "*";
                }
                Console.WriteLine(input);
            }
            Console.ReadLine();
        }
    }
}
