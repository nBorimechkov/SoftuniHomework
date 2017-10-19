using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            bool nowSearching = false;
            string result = "";

            while (input != "stop")
            {
                if (!nowSearching)
                {
                    string[] contact = input.Split('-');
                    if (!dictionary.ContainsKey(contact[0]))
                    {
                        dictionary.Add(contact[0], contact[1]);
                    }
                    else
                    {
                        dictionary[contact[0]] = contact[1];
                    }
                }
                else
                {
                    if (!dictionary.ContainsKey(input))
                    {
                        Console.WriteLine("Contact " + input + " does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(input + " -> " + dictionary[input]);
                    }
                }

                input = Console.ReadLine();
                if (input == "search")
                {
                    nowSearching = true;
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
