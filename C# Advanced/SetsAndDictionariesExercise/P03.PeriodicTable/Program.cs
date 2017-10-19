using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = new string[n];
            var set = new SortedSet<string>();
            string result = "";

            for (int i = 0; i < n; i++)
            {
                inputs[i] = Console.ReadLine();
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                string[] split = inputs[i].Split(' ');
                if (split.Length > 1)
                {
                    for (int j = 0; j < split.Length; j++)
                    {
                        set.Add(split[j]);
                    }
                }
                else if (split.Length == 1)
                {
                    set.Add(split[0]);
                }
            }
            foreach (var item in set)
            {
                result += item + " ";
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
