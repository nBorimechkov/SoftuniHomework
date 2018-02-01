using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.CountOfOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            SortedDictionary<int, int> occurances = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (occurances.ContainsKey(numbers[i]))
                {
                    occurances[numbers[i]]++;
                }
                else
                {
                    occurances.Add(numbers[i], 1);
                }
            }
            foreach (var key in occurances.Keys)
            {
                Console.WriteLine($"{key} -> {occurances[key]} times");
            }
        }
    }
}
