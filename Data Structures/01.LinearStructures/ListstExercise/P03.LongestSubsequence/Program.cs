using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.LongestSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Dictionary<int, int> indices = new Dictionary<int, int>();
            int startIndex = -1;
            int sequenceLength = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    if (startIndex == -1)
                    {
                        startIndex = i - 1;
                    }
                    sequenceLength++;
                }
                if (numbers[i - 1] != numbers[i] || i >= numbers.Count - 1)
                {
                    if (sequenceLength != 0)
                    {
                        indices.Add(startIndex, sequenceLength);
                        sequenceLength = 0;
                        startIndex = -1;
                    }
                }
            }
            var orderedIndices = indices.OrderByDescending(kvp => kvp.Value);
            foreach (KeyValuePair<int, int> kvp in orderedIndices)
            {
                for (int i = kvp.Key; i < kvp.Value + kvp.Key + 1; i++)
                {
                    Console.Write($"{numbers[i]} ");
                }
                break;
            }
            if (indices.Keys.Count == 0)
            {
                Console.WriteLine(numbers[0]);
            }
            Console.ReadLine();
        }
    }
}
