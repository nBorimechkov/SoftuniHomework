using System;
using System.Linq;

namespace P04.Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = int.Parse(Console.ReadLine());
            int[] bestPrice = new int[prices.Length];
            int[] bestCombo = new int[prices.Length];

            
            Solution(CutRod(length));

            int CutRod(int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    int currentBest = bestPrice[i];
                    for (int j = 1; j <= i; j++)
                    {
                        currentBest = Math.Max(bestPrice[i], prices[j] + bestPrice[i - j]);
                        if (currentBest > bestPrice[i])
                        {
                            bestPrice[i] = currentBest;
                            bestCombo[i] = j;
                        }
                    }
                }
                return bestPrice[n];
            }

            void Solution(int n)
            {
                while (n - bestCombo[n] != 0)
                {
                    Console.WriteLine(bestCombo[n] + " ");
                    n = n - bestCombo[n];
                }
                Console.WriteLine(bestCombo[n]);
            }
        }
    }
}
