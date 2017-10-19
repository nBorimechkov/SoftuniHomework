using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();
            List<string> usedCards = new List<string>();
            int currentTotal = 0;
            string[] types = { "0", "C", "D", "H", "S" };

            while (input != "JOKER")
            {
                string[] inputLine = input.Split(' ');
                string player = inputLine[0];
                if (!players.ContainsKey(player))
                {
                    players[player] = new List<string>();
                    players[player].Add("0");
                }
                for (int i = 1; i < inputLine.Length; i++)
                {                    
                    string[] afterSplit = inputLine[i].Split(',');
                    string card = afterSplit[0];
                   
                    if (!players[player].Contains(card))
                    {
                        players[player].Add(card);
                        string power = card.Substring(0, card.Length - 1);
                        string type = card.Substring(card.Length - 1, 1);

                        switch (power)
                        {
                            case "2":
                                currentTotal += 2 * Array.IndexOf(types, type);
                                break;
                            case "3":
                                currentTotal += 3 * Array.IndexOf(types, type);
                                break;
                            case "4":
                                currentTotal += 4 * Array.IndexOf(types, type);
                                break;
                            case "5":
                                currentTotal += 5 * Array.IndexOf(types, type);
                                break;
                            case "6":
                                currentTotal += 6 * Array.IndexOf(types, type);
                                break;
                            case "7":
                                currentTotal += 7 * Array.IndexOf(types, type);
                                break;
                            case "8":
                                currentTotal += 8 * Array.IndexOf(types, type);
                                break;
                            case "9":
                                currentTotal += 9 * Array.IndexOf(types, type);
                                break;
                            case "10":
                                currentTotal += 10 * Array.IndexOf(types, type);
                                break;
                            case "J":
                                currentTotal += 11 * Array.IndexOf(types, type);
                                break;
                            case "Q":
                                currentTotal += 12 * Array.IndexOf(types, type);
                                break;
                            case "K":
                                currentTotal += 13 * Array.IndexOf(types, type);
                                break;
                            case "A":
                                currentTotal += 14 * Array.IndexOf(types, type);
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
                players[player][0] = (int.Parse(players[player][0]) + currentTotal).ToString();
                currentTotal = 0;
                input = Console.ReadLine();
            }

            foreach (var player in players.Keys)
            { 
                Console.WriteLine(player + " " + players[player][0]);
            }
            Console.ReadLine();
        }
    }
}
