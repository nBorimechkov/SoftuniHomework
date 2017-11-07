using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(' ').ToList().ForEach(w => Console.WriteLine(w));
        }
    }
}
