using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.SpecialWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToCount = Console.ReadLine().Split(' ').ToArray();
            string[] split = Console.ReadLine().
                Split(new Char[] {'(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' });
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();

            foreach (var word in wordsToCount)
            {
                wordOccurances.Add(word, 0);
            }

            foreach (var target in split)
            {
                foreach (var word in wordsToCount)
                {
                    if (target == word)
                    {
                        wordOccurances[word]++;
                    }
                }
            }
            //TOFINISH
            foreach (var key in wordOccurances.Keys)
            {
                Console.WriteLine($"{key} - {wordOccurances[key]}");
            }
            Console.ReadLine();
        }
    }
}
