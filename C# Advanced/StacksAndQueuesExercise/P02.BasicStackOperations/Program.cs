using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            var stack = new Stack<int>();
            int push = int.Parse(arr[0]);
            int pop = int.Parse(arr[1]);
            int check = int.Parse(arr[2]);

            string toPush = Console.ReadLine();
            string[] numbers = toPush.Split(' ');
            foreach (string numebr in numbers)
            {
                stack.Push(int.Parse(numebr));
            }

            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(check))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count > 0)
            {
                var array = stack.ToArray();
                int min = array.Min();
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine(0);
            }
            Console.ReadLine();
        }
    }
}
