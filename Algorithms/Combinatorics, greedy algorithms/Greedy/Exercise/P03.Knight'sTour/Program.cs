using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Knight_sTour
{
    class Program
    {
        // fucking shit flips on me, can't deal with ties
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            SortedDictionary<int, List<KeyValuePair<int, int>>> numberOfMoves = new SortedDictionary<int, List<KeyValuePair<int, int>>>();
            int steps = 1;
            int currentX = 0;
            int currentY = 0;

            while (true)
            {
                if (steps >= n * n)
                {
                    break;
                }
                matrix[currentX, currentY] = steps;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                steps++;
                var moves = PossibleMoves(currentX, currentY);
                foreach (var possibleMove in moves)
                {
                    int x = possibleMove.Key;
                    int y = possibleMove.Value;
                    int movesFromGivenCell = PossibleMoves(x, y).Count;
                    if (!numberOfMoves.ContainsKey(movesFromGivenCell))
                    {
                        numberOfMoves.Add(movesFromGivenCell, new List<KeyValuePair<int, int>>());
                        numberOfMoves[movesFromGivenCell].Add(new KeyValuePair<int, int>(x, y));
                    }
                    else
                    {
                        numberOfMoves[movesFromGivenCell].Add(new KeyValuePair<int, int>(x, y));
                    }
                    
                }

                currentX = numberOfMoves.First().Value.First().Key;
                currentY = numberOfMoves.First().Value.First().Value;
                numberOfMoves.Clear();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            bool IsIn(int x, int y)
            {
                if ((x >= 0 && x < n) && (y >= 0 && y < n))
                {
                    return true;
                }
                return false;
            }

            List<KeyValuePair<int, int>> PossibleMoves(int x, int y)
            {
                List<KeyValuePair<int, int>> results = new List<KeyValuePair<int, int>>();

                if (IsIn(x - 1, y + 2) && matrix[x - 1, y + 2] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x - 1, y + 2));
                }
                if (IsIn(x + 1, y + 2) && matrix[x + 1, y + 2] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x + 1, y + 2));
                }
                if (IsIn(x - 1, y - 2) && matrix[x - 1, y - 2] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x - 1, y - 2));
                }
                if (IsIn(x + 1, y - 2) && matrix[x + 1, y - 2] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x + 1, y - 2));
                }


                if (IsIn(x - 2, y + 1) && matrix[x - 2, y + 1] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x - 2, y + 1));
                }
                if (IsIn(x - 2, y - 1) && matrix[x - 2, y - 1] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x - 2, y - 1));
                }
                if (IsIn(x + 2, y + 1) && matrix[x + 2, y + 1] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x + 2, y + 1));
                }
                if (IsIn(x + 2, y - 1) && matrix[x + 2, y - 1] == 0)
                {
                    results.Add(new KeyValuePair<int, int>(x + 2, y - 1));
                }

                
                return results;
            }
        }
    }
}
