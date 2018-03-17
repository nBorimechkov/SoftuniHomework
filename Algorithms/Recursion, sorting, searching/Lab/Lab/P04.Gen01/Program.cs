﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Gen01
{
    class Program
    {
        static void Main(string[] args)
        {
            Gen01(new int[int.Parse(Console.ReadLine())], );
            Console.ReadLine();
        }

        private static void Gen01(int[] vector, int index)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }
        }
    }
}
