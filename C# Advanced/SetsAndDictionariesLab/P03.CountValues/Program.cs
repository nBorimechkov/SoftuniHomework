using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.CountValues
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();
            string input = Console.ReadLine();
            
            string[] array = input.Split(' ');

            double[] numbers = Array.ConvertAll(array, double.Parse);

            foreach (int number in numbers)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 1);
                }
                else
                {
                    dictionary[number]++;
                }
            }

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(key + " - " + dictionary[key] + " times");
            }

            Console.ReadLine();
        }
    }
}
