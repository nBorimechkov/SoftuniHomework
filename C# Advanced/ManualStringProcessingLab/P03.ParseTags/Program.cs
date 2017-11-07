using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text.IndexOf("<upcase>") != -1)
            {
                int startIndex = text.IndexOf("<upcase>");
                int endIndex = text.IndexOf("</upcase>");
                string textToModify = text.Substring(startIndex + 8, endIndex - startIndex - 8);
                string textToReplace = $"<upcase>{textToModify}</upcase>";
                text = text.Replace(textToReplace, textToModify.ToUpper());
            }
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
