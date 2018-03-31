namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }

            Console.ReadLine();
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> usedCoins = new Dictionary<int, int>();
            IList<int> sortedCoins = coins.OrderByDescending(c => c).ToList();
            int currentSum = 0;
            int index = 0;

            while (true)
            {
                if (currentSum == targetSum)
                {
                    break;
                }
                else if (currentSum > targetSum || index >= sortedCoins.Count)
                {
                    Console.WriteLine("Error");
                    throw new InvalidOperationException();
                }
                if (currentSum + sortedCoins[index] > targetSum)
                {
                    index++;
                    continue;
                }
                else
                {
                    if (!usedCoins.ContainsKey(sortedCoins[index]))
                    {
                        usedCoins.Add(sortedCoins[index], 1);
                    }
                    else
                    {
                        usedCoins[sortedCoins[index]]++;
                    }
                    currentSum += sortedCoins[index];
                }
            }

            return usedCoins;
        }
    }
}