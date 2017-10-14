using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string initial = input.ToString();
            var stack = new Stack<string>();
            int remainder = 0;
            string result = "";

            while (input > 0)
            {
                remainder = input % 2;
                input /= 2;
                stack.Push(remainder.ToString());
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            if (initial == "0")
            {
                result = "0";
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
