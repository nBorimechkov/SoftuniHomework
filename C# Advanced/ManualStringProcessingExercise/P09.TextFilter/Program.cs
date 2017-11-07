using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToBan = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            string[] text = Console.ReadLine().Split(' ');
            string filteredText = "";

            foreach (var wordToBan in wordsToBan)
            {
                foreach (var word in text)
                {
                    if (word.Contains(wordToBan))
                    {
                        string replaceWith = "";
                        for (int i = 0; i < wordToBan.Length; i++)
                        {
                            replaceWith += "*";
                        }
                        string filtered = word.Replace(wordToBan, replaceWith);
                        filteredText += filtered + " ";
                    }
                    else
                    {
                        filteredText += word + " ";
                    }
                }
            }
            Console.WriteLine(filteredText);
            Console.ReadLine();
        }
    }
}
