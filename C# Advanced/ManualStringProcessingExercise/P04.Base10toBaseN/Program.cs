using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Base10toBaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(' ').ToArray();
            double baseN = double.Parse(parameters[0]);
            double number = double.Parse(parameters[1]);
            List<int> powersOfBaseN = new List<int>();
            int temp = (int)baseN;
            double pow = 0;
            int remainder = 0;
            int whole = 0;
            int divisor = 0;
            string result = "";

            while (Math.Pow(baseN, pow) < number)
            {
                temp = (int)Math.Pow(baseN, pow);
                powersOfBaseN.Add(temp);
                pow++;
            }
            powersOfBaseN.Reverse();

            for (int i = 0; i < powersOfBaseN.Count; i++)
            {
                divisor = powersOfBaseN[i];
                whole = (int)number / divisor;
                remainder = (int)number % divisor;
                number = remainder;
                result += whole;
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
