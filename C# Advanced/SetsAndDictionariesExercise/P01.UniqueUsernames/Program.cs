using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string current = Console.ReadLine();
                if (!list.Contains(current))
                {
                    list.Add(current);
                }
            }

            foreach (var name in list)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }
    }
}
