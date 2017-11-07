using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.ConcatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                text.Append(Console.ReadLine()).Append(" ");
            }
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
