using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ProcessorScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTasks = int.Parse(Console.ReadLine().Split(new string[] { "Tasks: " }, StringSplitOptions.RemoveEmptyEntries)[0]);

            Dictionary<int, List<int>> tasks = new Dictionary<int, List<int>>();
            List<int> indices = new List<int>();
            List<int> results = new List<int>();
            int totalSum = 0;

            for (int i = 0; i < numberOfTasks; i++)
            {
                int[] currentItem = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (!tasks.ContainsKey(currentItem[1]))
                {
                    tasks.Add(currentItem[1], new List<int>());
                    tasks[currentItem[1]].Add(currentItem[0]);
                    indices.Add(currentItem[0]);
                }
                else
                {
                    tasks[currentItem[1]].Add(currentItem[0]);
                    indices.Add(currentItem[0]);
                }
            }



            var ordered = tasks.OrderBy(kvp => kvp.Key).ToList();

            for (int i = 0; i < ordered.Count; i++)
            {
                int currentValue = ordered[i].Value.Max();
                
                if (i + 1 < ordered.Count && ordered[i + 1].Value.Max() > currentValue)
                {
                    currentValue = ordered[i + 1].Value.Max();
                    i++;
                }
                totalSum += currentValue;
                results.Add(indices.IndexOf(currentValue) + 1);
            }
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
