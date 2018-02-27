using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ReverseNumbersStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.ReadLine();
        }
    }
}
