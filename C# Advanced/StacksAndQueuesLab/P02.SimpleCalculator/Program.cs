using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<string>();
            string[] arr = input.Split(' ');
            int sum = 0;

            Array.Reverse(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }

           

            sum = int.Parse(stack.Pop());
            
            
                       
            while (stack.Count > 1)
            {
                if(stack.Peek() == "+")
                {
              
                    stack.Pop();
             
                    sum = sum + int.Parse(stack.Pop());
                    
                }
                else 
                {
                   
                    stack.Pop();
                 
                    sum = sum - int.Parse(stack.Pop());
                    
                }
              
            }

            //    2 + 5 + 10 - 2 - 1      //
            Console.WriteLine(sum);
            Console.ReadLine();
        }

    }
}
