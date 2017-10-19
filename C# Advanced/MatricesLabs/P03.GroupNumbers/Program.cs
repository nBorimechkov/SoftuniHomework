using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ',', ' ' },
                               StringSplitOptions.RemoveEmptyEntries).ToArray().Select(int.Parse);
            int[] sizes = new int[3];
            foreach (var number in numbers)
            {
                int remainder = number % 3;
                sizes[remainder]++;
            }

            int[][] matrix =
            {
              new int[sizes[0]],
              new int[sizes[1]],
              new int[sizes[2]]
            };

            int[] offsets = new int[3];
            foreach (var number in numbers)
            {
                int reminder = number % 3;
                int index = offsets[reminder];
                matrix[reminder][index] = number;
                offsets[reminder]++;
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
