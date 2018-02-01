using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int s1 = int.Parse(Console.ReadLine());
            int count = 2;
            int s2;
            int s3;
            int s4;
            Console.Write(s1 + ", ");
            while (count <= 50)
            {
                s2 = s1 + 1;
                s3 = 2 * s1 + 1;
                s4 = s1 + 2;
                Console.Write($"{s2}, ");
                Console.Write($"{s3}, ");
                Console.Write($"{s4}, ");
                s1 = s2;
                count++;
            }
            Console.ReadLine();
        }
    }
}
