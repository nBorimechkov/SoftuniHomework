using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string input = Console.ReadLine();

            while (input != "stop")
            {

                string email = Console.ReadLine();
                dictionary.Add(input, email);
                
                input = Console.ReadLine();
            }

            foreach (var entry in dictionary.Keys)
            {
                if (!dictionary[entry].Contains(".uk") && !dictionary[entry].Contains(".us"))
                {
                    Console.WriteLine(entry + " -> " + dictionary[entry]);
                }
            }

            
            Console.ReadLine();
        }
    }
}
