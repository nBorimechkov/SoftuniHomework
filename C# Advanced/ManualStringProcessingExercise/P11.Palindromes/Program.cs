using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ',', ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> palindromes = new SortedSet<string>();
            foreach (var word in words)
            {
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                string reversedWord = new string(arr);
                if (word.Equals(reversedWord))
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine("[" + string.Join(", ", palindromes) + "]");
            Console.ReadLine();
        }
    }
}
