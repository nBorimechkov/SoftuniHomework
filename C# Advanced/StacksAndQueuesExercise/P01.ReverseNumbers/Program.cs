using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            var stack = new Stack<string>();
            string result = "";

            foreach (string numebr in arr)
            {
                stack.Push(numebr);
            }

            foreach (string number in stack)
            {
                result += number + " ";
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
