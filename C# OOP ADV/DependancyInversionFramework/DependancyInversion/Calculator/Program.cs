using _03DependencyInversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] operands = input.Split(' ');
                if (operands[0] == "mode")
                {
                    char operand = operands[1][0];
                    calculator.ChangeStrategy(operand);
                }
                else
                {
                    int firstOperand = int.Parse(operands[0]);
                    int secondOperand = int.Parse(operands[1]);
                    Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));
                }
            }
            Console.ReadLine();
        }
    }
}
