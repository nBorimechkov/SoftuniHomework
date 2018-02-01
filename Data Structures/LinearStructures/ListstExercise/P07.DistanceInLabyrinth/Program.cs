using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.DistanceInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            string[,] labyrinth = new string[dimensions, dimensions];

            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < dimensions; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < dimensions; j++)
                {
                    labyrinth[i, j] = row[j].ToString();
                }
            }

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
                Console.WriteLine();
            }

            Traverse(startRow, startCol, dimensions, labyrinth);

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    Console.Write(labyrinth[row, col]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Traverse(int startRow, int startCol, int dimensions, string[,] matrix)
        {
            int count = 1;
            matrix = FirstEmptyCell(startRow, startCol, dimensions, matrix);
            while (ReachableRemaining(matrix, dimensions))
            {
                for (int row = 0; row < dimensions; row++)
                {
                    for (int col = 0; col < dimensions; col++)
                    {
                        if (matrix[row, col] == count.ToString())
                        {
                            if (row + 1 < dimensions && matrix[row + 1, col] == "0")
                            {
                                matrix[row + 1, col] = (count + 1).ToString();
                            }
                            if (row - 1 >= 0 && matrix[row - 1, col] == "0")
                            {
                                matrix[row - 1, col] = (count + 1).ToString();
                            }
                            if (col + 1 < dimensions && matrix[row, col + 1] == "0")
                            {
                                matrix[row, col + 1] = (count + 1).ToString();
                            }
                            if (col - 1 >= 0 && matrix[row, col - 1] == "0")
                            {
                                matrix[row, col - 1] = (count + 1).ToString();
                            }
                        }
                    }
                }
                for (int row = 0; row < dimensions; row++)
                {
                    for (int col = 0; col < dimensions; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                if (count > 12)
                {
                    break;
                }
                count++;
            }
        }

        static string[,] FirstEmptyCell(int row, int col, int dimensions, string[,] matrix)
        {
            if (row + 1 < dimensions && matrix[row + 1, col] != "x")
            {
                matrix[row + 1, col] = "1";
            }
            if  (row - 1 >= 0 && matrix[row - 1, col] != "x")
            {
                matrix[row - 1, col] = "1";
            }
            if (col + 1 < dimensions && matrix[row, col + 1] != "x")
            {
                matrix[row, col + 1] = "1";
            }
            if (col - 1 >= 0 && matrix[row, col - 1] != "x")
            {
                matrix[row, col - 1] = "1";
            }
            return matrix;
        }

        static bool ReachableRemaining(string[,] matrix, int dimensions)
        {
            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    if (matrix[row, col] == "0" && !IsEnclosed(row, col, dimensions, matrix))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // fails when there are multiple enclosed cells in a group
        static bool IsEnclosed(int row, int col, int dimensions, string[,] matrix)
        {
            if (((row + 1 < dimensions && matrix[row + 1, col] == "x") || row + 1 >= dimensions) &&
                ((row - 1 >= 0 && matrix[row - 1, col] == "x") || row - 1 < 0) &&
                ((col + 1 < dimensions && matrix[row, col + 1] == "x") || col + 1 >= dimensions) &&
                ((col - 1 >= 0 && matrix[row, col - 1] == "x") || col - 1 < 0))
            {
                return true;
            }
            return false;
        }
    }
}
