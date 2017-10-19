using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[][] matrix = new string[rows][];
            string snake = Console.ReadLine();
            int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetRow = parameters[0];
            int targetCol = parameters[1];
            int radius = parameters[2];

            int stringLengthTarget = rows * cols;
            while (snake.Length < stringLengthTarget)
            {
                snake += snake;
            }

            int fillCounter = 0;
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new string[cols];
                if (rowIndex % 2 == 0)
                {
                    for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[fillCounter].ToString();
                        fillCounter++;
                    }
                }
                else
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[fillCounter].ToString();
                        fillCounter++;
                    }
                }
            }

            // create a list with all cells that are targeted
            HashSet<string> targetedCells = new HashSet<string>();
            for (int i = targetRow - radius; i <= targetRow + radius; i++)
            {
                targetedCells.Add(i + " " + targetCol);
            }
            for (int j = targetCol - radius; j <= targetCol + 2; j++)
            {
                targetedCells.Add(targetRow + " " + j);
            }
            for (int rowIndex = targetRow - (radius - 1); rowIndex <= targetRow + (radius - 1); rowIndex++)
            {
                for (int colIndex = targetCol - (radius - 1); colIndex <= targetCol + (radius - 1); colIndex++)
                {
                    targetedCells.Add(rowIndex + " " + colIndex);
                }
            }
            
            //replace targeted cells with a space
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    string currentCell = rowIndex + " " + colIndex;
                    if (targetedCells.Contains(currentCell))
                    {
                        matrix[rowIndex][colIndex] = " ";
                    }
                }
            }
            Console.WriteLine();
    

            for (int i = 0; i <= rows - radius; i++)
            {
                for (int rowIndex = 1; rowIndex < rows; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex].Equals(" "))
                        {
                            matrix[rowIndex][colIndex] = matrix[rowIndex - 1][colIndex];
                            matrix[rowIndex - 1][colIndex] = " ";
                        }
                    }
                }
            }
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    Console.Write(matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
