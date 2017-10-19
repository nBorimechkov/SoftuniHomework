using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputs = Console.ReadLine();
            string[] arr = inputs.Split(' ');
            int n = int.Parse(arr[0]);
            int m = int.Parse(arr[1]);
            int[] sets = new int[n + m];
            string result = "";

            var setN = new HashSet<int>();
            var setM = new HashSet<int>();


            for (int i = 0; i < sets.Length; i++)
            {
                sets[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                setN.Add(sets[i]);
            }

            for (int i = n; i < sets.Length; i++)
            {
                setM.Add(sets[i]);
            }

            if (n > m)
            {
                foreach (var number in setN)
                {
                    if (setM.Contains(number))
                    {
                        result += number + " ";
                    }
                }
            }
            else
            {
                foreach (var number in setM)
                {
                    if (setN.Contains(number))
                    {
                        result += number + " ";
                    }
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
