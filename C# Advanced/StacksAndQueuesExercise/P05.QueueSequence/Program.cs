using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.QueueSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            string result = n + " ";

            for (int i = 0; i < 16; i++)
            {
                queue.Enqueue(n + 1);
                result += (n + 1) + " ";

                queue.Enqueue(2 * n + 1);
                result += (2 * n + 1) + " ";

                queue.Enqueue(n + 2);
                result += (n + 2) + " ";

                n = queue.Dequeue();
            }

            result += n + 1;
            Console.WriteLine(result);
            string[] arr = result.Split(' ');
            
            Console.ReadLine();
        }
    }
}
