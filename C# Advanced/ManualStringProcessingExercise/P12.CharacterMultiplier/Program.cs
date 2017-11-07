using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string firstString = input[0];
            string secondString = input[1];
            int charSum = 0;

            if (firstString.Length == secondString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    charSum += (int)firstString[i] * (int)secondString[i];
                }
            }
            else
            {
                string shorterString = firstString.Length > secondString.Length ? secondString : firstString;
                string longerString = firstString.Length > secondString.Length ? firstString : secondString;
                for (int i = 0; i < shorterString.Length; i++)
                {
                    charSum += (int)firstString[i] * (int)secondString[i];
                }

                for (int i = shorterString.Length; i < longerString.Length; i++)
                {
                    charSum += (int)longerString[i];
                }
            }

            Console.WriteLine(charSum);
            Console.ReadLine();
        }
    }
}
