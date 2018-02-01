using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.OddOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Dictionary<int, int> occurances = new Dictionary<int, int>();
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
                if (occurances[key] % 2 != 0)
                {
                    numbers.RemoveAll(x => x == key);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
            Console.ReadLine();
        }
    }
}
