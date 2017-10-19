using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];
            }

                    for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string first = alphabet[row].ToString();
                    string middle = alphabet[row + col].ToString();
                    string last = alphabet[row].ToString();
                    string palindrome = first + middle + last;
                    matrix[row][col] = palindrome;
                }
            }

            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
