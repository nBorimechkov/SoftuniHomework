using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01.StudentResults
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double[]> dictionary = new Dictionary<string, double[]>();
            string input = "";

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] split = Regex.Split(input, " - ");
                string name = split[0];
                string[] stringGrades = Regex.Split(split[1], ", ");
                double[] grades = new double[stringGrades.Length + 1];

                for (int j = 0; j < stringGrades.Length; j++)
                {
                    grades[j] = double.Parse(stringGrades[j]);
                }
                dictionary.Add(name, grades);
                
            }
            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                                            "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (KeyValuePair<string, double[]> item in dictionary)
            {
                double average = item.Value.Average() + 1.0;
                double[] grades = item.Value;
                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                                                item.Key, grades[0], grades[1], grades[2], average));
            }
            Console.ReadLine();
        }
    }
}
