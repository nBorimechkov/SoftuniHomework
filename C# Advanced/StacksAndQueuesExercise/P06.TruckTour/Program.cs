using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                string[] current = arr[i].Split(' ');
                long petrol = long.Parse(current[0]);
                long distance = long.Parse(current[1]);
                if(petrol >= distance)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
