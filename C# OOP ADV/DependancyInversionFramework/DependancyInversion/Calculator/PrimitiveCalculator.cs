using Calculator;
using Calculator.CalculationStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03DependencyInversion
{
    class PrimitiveCalculator
    {
        private IStrategy strategy;

        private IStrategy addition = new AdditionStrategy();
        private IStrategy subtraction = new SubtractionStrategy();
        private IStrategy multiplication = new MultiplicationStrategy();
        private IStrategy division = new DivisionStrategy();

        public PrimitiveCalculator()
        {
            this.strategy = addition;
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator){
            case '+':
                    this.strategy = addition;
                break; 
            case '-':
                    this.strategy = subtraction;
                    break;
            case '*':
                    this.strategy = multiplication;
                break;
            case '/':
                    this.strategy = division;
                break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
