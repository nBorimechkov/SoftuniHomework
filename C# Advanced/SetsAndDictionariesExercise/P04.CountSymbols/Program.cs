using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dictionary.ContainsKey(input[i]))
                {
                    dictionary.Add(input[i], 1);
                }
                else
                {
                    dictionary[input[i]]++;
                }
            }

            foreach (var letter in dictionary.Keys)
            {
                Console.WriteLine(letter + ": " + dictionary[letter] + " time/s");
            }

            Console.ReadLine();
        }
    }
}
