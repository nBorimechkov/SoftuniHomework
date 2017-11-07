using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.UpperStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            words.Select(w => w.ToUpper())
                .ToList()
                .ForEach(w => Console.Write(w + " "));
        }
    }
}
