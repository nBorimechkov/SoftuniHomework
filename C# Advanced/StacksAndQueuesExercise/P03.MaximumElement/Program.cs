using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];
            var stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                string[] current = arr[i].Split(' ');
                if (current[0] == "1")
                {
                    stack.Push(int.Parse(current[1]));
                }
                else if (current[0] == "2")
                {
                    stack.Pop();
                }
                else
                {
                    int[] array = stack.ToArray();
                    int max = array.Max();
                    Console.WriteLine(max);
                }
            }
            Console.ReadLine();
        }
    }
}
