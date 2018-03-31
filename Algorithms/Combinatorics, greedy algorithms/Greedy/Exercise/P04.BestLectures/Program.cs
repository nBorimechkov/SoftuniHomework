using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.BestLectures
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine().Split(new string[] { "Lectures: " }, StringSplitOptions.RemoveEmptyEntries)[0]);

            Dictionary<string, KeyValuePair<int, int>> lectures = new Dictionary<string, KeyValuePair<int, int>>();
            Dictionary<string, KeyValuePair<int, int>> results = new Dictionary<string, KeyValuePair<int, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] currentItem = Console.ReadLine().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                string lecture = currentItem[0];
                int[] hours = currentItem[1].Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                lectures.Add(lecture, new KeyValuePair<int, int>(hours[0], hours[1]));
            }

            var orderedLectures = lectures.OrderBy(l => l.Value.Value).ToList();
            results.Add(orderedLectures.First().Key, orderedLectures.First().Value);

            while (true)
            {
                if (results.Last().Value.Value > orderedLectures.Last().Value.Key)
                {
                    break;
                }
                KeyValuePair<int, int> hours = results.Last().Value;
                string name = results.Last().Key;

                for (int i = 0; i < orderedLectures.Count(); i++)
                {
                    int start = orderedLectures[i].Value.Key;
                    int end = orderedLectures[i].Value.Value;
                    if (start > hours.Value)
                    {
                        results.Add(orderedLectures[i].Key, 
                            new KeyValuePair<int, int>(orderedLectures[i].Value.Key, orderedLectures[i].Value.Value));
                    }
                }
                
            }
            Console.WriteLine($"Lectures ({results.Count}):");
            foreach (var lecture in results)
            {
                Console.WriteLine($"{lecture.Value.Key}-{lecture.Value.Value} -> {lecture.Key}");
            }
            Console.ReadLine();
        }
    }
}
