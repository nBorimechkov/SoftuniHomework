using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Maximum3x3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            int currentSum = 0;
            int biggestSum = 0;
            int bigX = 0;
            int bigY = 0;


            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[i] = input;
            }

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    currentSum = matrix[i][j] + matrix[i + 1][j] + matrix[i][j + 1] +
                                matrix[i + 1][j + 1] + matrix[i + 1][j + 2] + matrix[i + 2][j + 2] +
                                matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i][j + 2];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        bigX = i;
                        bigY = j;
                    }
                }
            }
            Console.WriteLine(bigX);
            Console.WriteLine(bigY);
            Console.WriteLine("Sum = " + biggestSum);
            for (int i = bigX; i < bigX + 3; i++)
            {
                for (int j = bigY; j < bigY + 3; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
