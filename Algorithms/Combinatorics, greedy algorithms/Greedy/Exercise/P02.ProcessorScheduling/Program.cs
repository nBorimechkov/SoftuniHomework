using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ProcessorScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int tasks = int.Parse(Console.ReadLine().Split(new string[] { "Tasks: " }, StringSplitOptions.RemoveEmptyEntries)[0]);

            SortedDictionary<int, List<int>> list = new SortedDictionary<int, List<int>>();

            for (int i = 0; i < tasks; i++)
            {
                int[] currentItem = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (!list.ContainsKey(currentItem[1]))
                {
                    list.Add(currentItem[1], new List<int>());
                }
                else
                {
                    list[currentItem[1]].Add(currentItem[0]);
                }
            }

           

            Console.WriteLine();
            foreach (var kvp in list.OrderBy(kvp => kvp.Value).ThenByDescending(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            Console.ReadLine();
        }

        private static int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            throw new NotImplementedException();
        }
    }
}
