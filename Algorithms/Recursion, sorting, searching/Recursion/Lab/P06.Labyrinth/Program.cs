using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Labyrinth
{
    class Program
    {
        static List<char> path = new List<char>();
        static List<char[]> paths = new List<char[]>();
        static char[,] lab = new char[0, 0];

        static void Main(string[] args)
        {
            lab = ReadLab();
            FindPaths(0, 0, 'S');
            foreach (var path in paths)
            {
                for (int i = 1; i < path.Length; i++)
                {
                    Console.Write(path[i]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }       

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
                return;

            path.Add(direction);
            

            if (IsExit(row, col))
            {
                PrintPath(path);
            }

            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }
            path.RemoveAt(path.Count - 1);
        }

        private static char[,] ReadLab()
        {
            string input = " ";
            int row = 0;
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            lab = new char[rows, cols];
            while ((input = Console.ReadLine()) != "")
            {
                char[] line = input.ToCharArray();
                for (int col = 0; col < line.Length; col++)
                {
                    lab[row, col] = line[col];
                }
                row++;
            }
            return lab;
        }

        private static void Unmark(int row, int col)
        {
            lab[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            lab[row, col] = 'v';
        }

        private static bool IsVisited(int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static bool IsFree(int row, int col)
        {
            return lab[row, col] != '*';
        }

        private static void PrintPath(List<char> current)
        {
            char[] newPath = new char[current.Count];
            current.CopyTo(newPath);
            paths.Add(newPath);
        }

        private static bool IsExit(int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsInBounds(int row, int col)
        {
            bool isIn = true;
            if (row >= lab.GetLength(0) || row < 0)
            {
                isIn = false;
            }
            else if (col >= lab.GetLength(1) || col < 0)
            {
                isIn = false;
            }
            return isIn;
        }
    }
}
