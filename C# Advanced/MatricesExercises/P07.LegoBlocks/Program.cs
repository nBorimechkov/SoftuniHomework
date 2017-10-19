using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] firstArray = new string[rows][];
            string[][] secondArray = new string[rows][];
            
            bool areEqual = true;
            int combinedLength = 0;
            int numberOfCells = 0;

            for (int i = 0; i < rows; i++)
            {
                firstArray[i] = Console.ReadLine().Split(' ').ToArray();
            }
            for (int i = 0; i < rows; i++)
            {
                string[] arr = Console.ReadLine().Split(' ').ToArray();
                Array.Reverse(arr);
                secondArray[i] = arr;
            }

            combinedLength = firstArray[0].Length + secondArray[0].Length;
            for (int i = 0; i < rows; i++)
            {
                if ((firstArray[i].Length + secondArray[i].Length) != combinedLength)
                {
                    areEqual = false;
                }
            }

            if (!areEqual)
            {
                for (int i = 0; i < rows; i++)
                {
                    numberOfCells += firstArray[i].Length;
                }
                for (int i = 0; i < rows; i++)
                {
                    numberOfCells += secondArray[i].Length;
                }
                Console.WriteLine("The total number of cells is: " + numberOfCells);
            }
            else
            {
                string[][] combinedArray = new string[rows][];
                for (int i = 0; i < combinedArray.Length; i++)
                {
                    combinedArray[i] = new string[combinedLength];
                    Array.Copy(firstArray[i], combinedArray[i], firstArray[i].Length);
                    Array.Copy(secondArray[i], 0, combinedArray[i], firstArray[i].Length, secondArray[i].Length);
                }
                for (int row = 0; row < combinedArray.Length; row++)
                {
                    Console.WriteLine("[" + string.Join(", ", combinedArray[row]) + "]");
                }   
            }
            Console.ReadLine();
        }
    }
}
