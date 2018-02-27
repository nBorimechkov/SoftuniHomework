using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            words.Sort();
            Console.WriteLine(string.Join(" ", words));
            Console.ReadLine();
        }
    }
}
