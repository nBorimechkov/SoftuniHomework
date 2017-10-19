using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(new[] { ',', ' ' },
                                StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            int[,] matrix = new int[rows, cols];
            int currentSum = 0;
            int biggestSum = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(new[] { ',', ' ' },
                                StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(currentRow[col]);
                }
            }

            SortedDictionary<int, int[]> sums = new SortedDictionary<int, int[]>();

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (!sums.ContainsKey(currentSum))
                    {
                        sums.Add(currentSum, new int[] { i, j });
                    }
                }
            }

            var lastKeyValuePair = sums.Last();
            int biggestSumRow = lastKeyValuePair.Value[0];
            int biggestSumCol = lastKeyValuePair.Value[1];
            Console.WriteLine(matrix[biggestSumRow, biggestSumCol] + " " + matrix[biggestSumRow, biggestSumCol + 1]);
            Console.WriteLine(matrix[biggestSumRow + 1, biggestSumCol] + " " + matrix[biggestSumRow + 1, biggestSumCol + 1]);
            Console.WriteLine(lastKeyValuePair.Key);
            Console.ReadLine();
        }
    }
}
