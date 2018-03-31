﻿using System;


namespace P04.OrderedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Remove(9);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
