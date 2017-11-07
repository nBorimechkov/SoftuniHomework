using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.FirstName
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ').ToArray();
            string[] letters = Console.ReadLine().Split(' ').OrderBy(w => w).ToArray();

            string result = null;

            foreach (var letter in letters)
            {
                result = names.
                    Where(w => w.ToLower()
                    .StartsWith(letter.ToLower()))
                    .FirstOrDefault();

                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }
            }
            if (result == null)
            {
                Console.WriteLine("No match");
            }
            Console.ReadLine();
        }
    }
}
