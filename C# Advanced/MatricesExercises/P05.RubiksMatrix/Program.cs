using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int commands = int.Parse(Console.ReadLine());
            string[] commandLines = new string[commands];
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = new int[rows][];
            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    counter++;
                    matrix[i][j] = counter;
                }
            }
            for (int i = 0; i < commands; i++)
            {
                commandLines[i] = Console.ReadLine();
            }


            for (int i = 0; i < commandLines.Length; i++)
            {
                string[] arguments = commandLines[i].Split(' ');
                int index = int.Parse(arguments[0]);
                string direction = arguments[1];
                int moves = int.Parse(arguments[2]);


                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, index, moves);
                        break;
                    case "down":
                        MoveCol(matrix, index, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, index, moves);
                        break;
                    case "right":
                        MoveRow(matrix, index, cols - moves % cols);
                        break;
                    default:
                        break;
                }
            }

            var element = 1;
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    int currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
            Console.ReadLine();
        }

        

        private static void MoveRow(int[][] matrix, int index, int moves)
        {
            int[] temp = new int[matrix[0].Length];
            for (int coldIndex = 0; coldIndex < matrix[0].Length; coldIndex++)
            {
                temp[coldIndex] = matrix[index][(coldIndex + moves) % matrix[0].Length];
            }
            matrix[index] = temp;
        }

        private static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            int[] temp = new int[matrix.Length];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][rcIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][rcIndex] = temp[rowIndex];
            }
        }
    }
}
