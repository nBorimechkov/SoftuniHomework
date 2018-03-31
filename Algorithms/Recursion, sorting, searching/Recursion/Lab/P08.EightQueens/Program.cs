using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.EightQueens
{
    class Program
    {
        static int size = 8;
        static int solutions = 0;

        static bool[,] chessboard = new bool[size, size];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            PutQueens(0);

            Console.ReadLine();
        }

        static void PutQueens(int row)
        {
            if (row == size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPostions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }

        private static void MarkAllAttackedPostions(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !(attackedRows.Contains(row) || attackedCols.Contains(col) ||
                    attackedLeftDiagonals.Contains(col - row) || attackedRightDiagonals.Contains(col + row));
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutions++;
        }
    }
}
