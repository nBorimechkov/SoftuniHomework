using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            string input = Console.ReadLine();
            int counter = 0;

            while (input != "Stop")
            {
                if (!dictionary.ContainsKey(input))
                {
                    long quantity = long.Parse(Console.ReadLine());
                    dictionary.Add(input, quantity);
                }
                else
                {
                    long quantity = long.Parse(Console.ReadLine());
                    dictionary[input] += quantity;
                }
     
                input = Console.ReadLine();              
            }

            foreach (var entry in dictionary.Keys)
            {
                Console.WriteLine(entry + " -> " + dictionary[entry]);
            }
            Console.ReadLine();

        }
    }
}
