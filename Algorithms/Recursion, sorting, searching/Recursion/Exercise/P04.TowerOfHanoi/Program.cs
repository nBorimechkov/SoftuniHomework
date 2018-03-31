using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.TowerOfHanoi
{
    class Program
    {
        private static int steps = 0;

        private static Stack<int> source;
        private static readonly Stack<int> spare = new Stack<int>();
        private static readonly Stack<int> destination = new Stack<int>();

        static void Main(string[] args)
        {
            int disks = 3;
            source = new Stack<int>(Enumerable.Range(1, disks).Reverse());
            PrintRods();
            MoveDisks(disks, source, destination, spare);
            Console.ReadLine();
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Steps taken: {steps}");
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Steps taken: {steps}");
                PrintRods();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
        private static void PrintRods()
        {
            Console.WriteLine("--------------");
            Console.WriteLine($"Source: {string.Join(" ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(" ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(" ", spare.Reverse())}");
            Console.WriteLine();
        }

        // stack is emptied for some reason, should investigate
        private static void Move()
        {
            steps++;
            destination.Push(source.Pop());
            Console.WriteLine($"Steps taken: {steps}");
            PrintRods();
        }
    }
}
