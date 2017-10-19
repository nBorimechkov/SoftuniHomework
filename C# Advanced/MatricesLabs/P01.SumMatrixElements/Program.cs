using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.SumMatrixElements
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
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(new[] { ',', ' ' },
                                StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(currentRow[col]);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }

            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
