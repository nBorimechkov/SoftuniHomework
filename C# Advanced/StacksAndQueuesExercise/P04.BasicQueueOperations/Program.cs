using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            var queue = new Queue<int>();
            int enqueue = int.Parse(arr[0]);
            int dequeue = int.Parse(arr[1]);
            int check = int.Parse(arr[2]);

            string toPush = Console.ReadLine();
            string[] numbers = toPush.Split(' ');
            foreach (string numebr in numbers)
            {
                queue.Enqueue(int.Parse(numebr));
            }

            for (int i = 0; i < dequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(check))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                var array = queue.ToArray();
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
