using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTable;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashDict<string, string> table = new HashDict<string, string>();

            string input = string.Empty;
            bool search = false;

            while ((input = Console.ReadLine()) != "end")
            {
                if (!search)
                {
                    search = input == "search" ? true : false;
                }
                if (!search)
                {
                    string[] commandArgs = input.Split('-');
                    string name = commandArgs[0];
                    string number = commandArgs[1];

                    if (!table.ContainsKey(name))
                    {
                        table.Add(name, number);
                    }
                }
                else if (input != "search")
                {
                    if (!table.ContainsKey(input))
                    {
                        Console.WriteLine($"Contact {input} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{input} -> {table[input]}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}