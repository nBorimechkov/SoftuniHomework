using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.EvenNumebrs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()


.Split(new string[] { " " },



StringSplitOptions.RemoveEmptyEntries)


.Select(n => int.Parse(n))


.Where(n => n % 2 != 0)


.OrderBy(n => n)


.ToList()


.ForEach(n => Console.WriteLine(n));
        }
    }
}
