using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Unfinished
namespace P15.MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int indexFirstMatch = text.IndexOf(pattern);
                int indexLastMatch = text.LastIndexOf(pattern);
                if (indexFirstMatch != -1 && indexLastMatch != -1 && indexFirstMatch != indexLastMatch)
                {
                    text = text.Remove(indexFirstMatch, pattern.Length);
                    text = text.Insert(indexFirstMatch, "");
                    text = text.Remove(indexLastMatch - pattern.Length, pattern.Length);
                    text = text.Insert(indexLastMatch - pattern.Length, "");
                    Console.WriteLine("Shaked it.");
                    if (pattern.Length > 0)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                    else
                    {
                        Console.WriteLine("No shake.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
