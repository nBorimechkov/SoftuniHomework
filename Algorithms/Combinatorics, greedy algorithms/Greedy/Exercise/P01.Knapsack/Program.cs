using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine().Split(new string[] { "Capacity: " }, StringSplitOptions.RemoveEmptyEntries)[0]);
            int items = int.Parse(Console.ReadLine().Split(new string[] { "Items: " }, StringSplitOptions.RemoveEmptyEntries)[0]);
            double totalPrice = 0;

            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < items; i++)
            {
                double[] currentItem = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                list.Add(new KeyValuePair<double, double>(currentItem[0], currentItem[1]));
            }

            list.Sort(Compare);

            foreach (var kvp in list)
            {
                if (capacity - kvp.Value >= 0)
                {
                    capacity -= (int)kvp.Value;
                    totalPrice += kvp.Key;
                    Console.WriteLine($"Take 100% of item with price {kvp.Key:0.00} and weight {kvp.Value:0.00}");
                }
                else 
                {
                    double percentage = (capacity / kvp.Value) * 100;
                    totalPrice += (percentage * kvp.Key) / 100.00;
                    Console.WriteLine($"Take {percentage:0.00}% of item with price {kvp.Key:0.00} and weight {kvp.Value:0.00}");
                    break;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:0.00}");
            Console.ReadLine();
        }

        static int Compare(KeyValuePair<double, double> one, KeyValuePair<double, double> two)
        {
            double result1 = one.Key / one.Value;
            double result2 = two.Key / two.Value;

            if (result1 > result2)
            {
                return -1;
            }
            else if (result1 < result2)
            {
                return 1;
            }
            return 0;
        }
    }
}
