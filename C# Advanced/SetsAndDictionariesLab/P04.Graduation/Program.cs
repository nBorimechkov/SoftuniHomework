using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, double> dictionary = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string person = Console.ReadLine();
                string grades = Console.ReadLine();
                grades = grades.Trim();
                double[] numberGrades = grades.Split(' ').Select(x => Convert.ToDouble(x)).ToArray();
                double average = numberGrades.Average();
                dictionary.Add(person, average);
            }

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(key + " is graduated with " + dictionary[key]);
            }

            Console.ReadLine();
        }   
    }
}
