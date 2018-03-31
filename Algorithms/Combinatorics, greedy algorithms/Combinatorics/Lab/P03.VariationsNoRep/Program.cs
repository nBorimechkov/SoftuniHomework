using System;
using System.Linq;

namespace P03.VariationsNoRep
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
                        if (!used[i])
                        {
                            used[i] = true;
                            vari[index] = elements[i];
                            Gen(index + 1);
                            used[i] = false;
                        }
            }
        }
        
    }
}
