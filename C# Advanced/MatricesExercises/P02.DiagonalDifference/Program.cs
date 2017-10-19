using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];
            int leftRightDiagonalSum = 0;
            int rightLeftDiagonalSum = 0;

            for (int i = 0; i < size; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[i] = input;
            }

            for (int rowAndCol = 0; rowAndCol < size; rowAndCol++)
            {
                leftRightDiagonalSum += matrix[rowAndCol][rowAndCol];
            }

            int col = size - 1;
            for (int row = 0; row < size; row++)
            {
                rightLeftDiagonalSum += matrix[row][col];
                col--;
            }

            Console.WriteLine(leftRightDiagonalSum);
            Console.WriteLine(rightLeftDiagonalSum);
            Console.WriteLine(Math.Abs(leftRightDiagonalSum - rightLeftDiagonalSum));

            Console.ReadLine();
        }
    }
}
