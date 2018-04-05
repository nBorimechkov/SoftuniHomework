using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            List<int[]> result = new List<int[]>();

            result.Add(new int[] { 0, 0 });

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var sums = new int[rows, cols];

            sums[0, 0] = matrix[0, 0];

            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + matrix[row, 0];
            }
            for(int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    // unreadable ternary initilization just to see if I could
                    // compares cell on top of current and to the left of current
                    // takes the larger ones and sums it with the current cell value
                    sums[row, col] = sums[row - 1, col] > sums[row, col - 1] ?
                        sums[row - 1, col] + matrix[row, col] : sums[row, col - 1] + matrix[row, col];
                }
            }

            int currentRow = 0;
            int currentCol = 0;

            while (true)
            {
                int down = currentRow;
                int right = currentCol;

                if (down >= rows - 1 && right >= cols - 1)
                {
                    break;
                }

                if (down >= rows - 1)
                {
                    result.Add(new int[] { down, right + 1 });
                    currentCol++;
                    continue;
                }

                if (right >= cols - 1)
                {
                    result.Add(new int[] { down + 1, right });
                    currentRow++;
                    continue;
                }

                if (matrix[down + 1, right] >= matrix[down, right + 1])
                {
                    result.Add(new int[] { down + 1, right });
                    currentRow++;
                }
                else if (matrix[down + 1, right] < matrix[down, right + 1])
                {
                    result.Add(new int[] { down, right + 1 });
                    currentCol++;
                }

            }


            foreach (var arr in result)
            {
                Console.Write($"[{string.Join(", ", arr)}] ");
            }
            Console.ReadLine();

            Console.ReadLine();

            // greedy solution
            #region
            //    int rows = int.Parse(Console.ReadLine());
            //    int cols = int.Parse(Console.ReadLine());
            //    int[,] matrix = new int[rows, cols];
            //    int[] current = new[] { 0, 0 };
            //    List<int[]> result = new List<int[]>();

            //    result.Add(new int[] { 0, 0 });

            //    for (int row = 0; row < rows; row++)
            //    {
            //        int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //        for (int col = 0; col < line.Length; col++)
            //        {
            //            matrix[row, col] = line[col];
            //        }
            //    }

            //    while (true)
            //    {
            //        int down = current[0];
            //        int right = current[1];

            //        if (down >= rows - 1 && right >= cols - 1)
            //        {
            //            break;
            //        }

            //        if (down >= rows - 1)
            //        {
            //            result.Add(new int[] { down, right + 1 });
            //            current[1]++;
            //            continue;
            //        }

            //        if (right >= cols - 1)
            //        {
            //            result.Add(new int[] { down + 1, right });
            //            current[0]++;
            //            continue;
            //        }

            //        if (matrix[down + 1, right] >= matrix[down, right + 1])
            //        {
            //            result.Add(new int[] { down + 1, right });
            //            current[0]++;
            //        }
            //        else if (matrix[down + 1, right] < matrix[down, right + 1])
            //        {
            //            result.Add(new int[] { down, right + 1 });
            //            current[1]++;
            //        }

            //    }


            //    foreach (var arr in result)
            //    {
            //        Console.Write($"[{string.Join(", ", arr)}] ");
            //    }
            //    Console.ReadLine();
            //}

            #endregion
        }
    }
}
