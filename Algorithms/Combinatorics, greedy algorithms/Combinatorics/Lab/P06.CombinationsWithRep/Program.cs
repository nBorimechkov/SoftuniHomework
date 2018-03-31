using System;
using System.Linq;

namespace P06.CombinationsWithRep
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ').ToArray();
            int k = int.Parse(Console.ReadLine());

            string[] combs = new string[k];
            Gen(0, 0);
            Console.ReadLine();

            void Gen(int index, int start)
            {
                if (index >= k)
                    Console.WriteLine(string.Join(" ", combs));
                else
                    for (int i = start; i < elements.Length; i++)
                    {
                        combs[index] = elements[i];
                        Gen(index + 1, i);
                    }
            }
        }
    }
  }

