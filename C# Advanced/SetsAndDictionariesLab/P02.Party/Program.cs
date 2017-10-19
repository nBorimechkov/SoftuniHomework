using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var guests = new HashSet<string>();
            var party = new HashSet<string>();
            var missed = new SortedSet<string>();
            bool started = false;

            while (input != "END")
            {
                if (input == "PARTY")
                {
                    started = true;
                }

                if (started)
                {
                    party.Add(input);
                }
                else
                {
                    guests.Add(input);
                }

                input = Console.ReadLine();
            }

            foreach (var person in guests)
            {
                if (!party.Contains(person))
                {
                    missed.Add(person);
                }
            }

            Console.WriteLine(missed.Count);

            foreach (var guest in missed)
            {
                Console.WriteLine(guest);
            }

            Console.ReadLine();
        }
    }
}
