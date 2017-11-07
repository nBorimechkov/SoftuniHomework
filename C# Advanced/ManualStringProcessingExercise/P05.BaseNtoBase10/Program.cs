using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.BaseNtoBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(' ').ToArray();
            int baseN = int.Parse(parameters[0]);
            int[] digits = parameters[1].ToString().Select(t => int.Parse(t.ToString())).ToArray();
            int base10Sum = 0;
            Array.Reverse(digits);

            for (int i = 0; i < digits.Length; i++)
            {
                base10Sum += digits[i] * (int)(Math.Pow(baseN, i));
            }
            Console.WriteLine(base10Sum);
            Console.ReadLine();
        }
    }
}
