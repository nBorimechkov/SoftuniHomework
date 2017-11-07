using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.SubstringOccurance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ').ToArray();
            string substring = Console.ReadLine();
            int occuranceCount = 0;

            foreach (string word in text)
            {
                if (word.ToLower().Contains(substring))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((i + substring.Length) <= word.Length && word.ToLower().Substring(i, substring.Length).Contains(substring))
                        {
                            occuranceCount++;
                        }
                    }
                }
            }
            Console.WriteLine(occuranceCount);
            Console.ReadLine();
        }
    }
}
