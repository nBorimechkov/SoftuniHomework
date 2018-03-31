using System;
using System.Linq;

namespace P04.VariationsWithRep
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ').ToArray();
            int k = int.Parse(Console.ReadLine());

            string[] vari = new string[k];
            bool[] used = new bool[elements.Length];
            Gen(0);
            Console.ReadLine();

            void Gen(int index)
            {
                if (index >= k)
                    Console.WriteLine(string.Join(" ", vari));
                else
                    for (int i = 0; i < elements.Length; i++)
                    {
                        vari[index] = elements[i];
                        Gen(index + 1);
                    }
            }
        }
    }
}
