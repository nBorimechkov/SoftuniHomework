using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03._2x2Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[][] matrix = new string[rows][];
            int squareCounter = 0;
            
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                matrix[i] = input;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i][j] == matrix[i + 1][j] &&
                        matrix[i][j] == matrix[i][j + 1] &&
                        matrix[i][j] == matrix[i + 1][j + 1])
                    {
                        squareCounter++;
                    }
                }
            }
            Console.WriteLine(squareCounter);
        }
    }
}
