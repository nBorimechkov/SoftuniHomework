using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Knights
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(w => Console.WriteLine("Sir " + w));
        }
    }
}
