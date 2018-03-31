using HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HashDict
{
    class Program
    {
        static void Main(string[] args)
        {
            HashDict<char, int> table = new HashDict<char, int>();

            string input = Console.ReadLine();

            foreach (var letter in input)
            {
                if (!table.ContainsKey(letter))
                {
                    table.Add(letter, 1);
                }
                else
                {
                    table[letter]++;
                }
            }

            foreach (var letter in table.Keys)
            {
                Console.WriteLine($"{letter}: {table[letter]} time/s");
            }
            Console.ReadLine();
        }
    }

}