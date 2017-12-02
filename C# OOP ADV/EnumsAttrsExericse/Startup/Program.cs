using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    static void Main(string[] args)
    {
        string player1 = Console.ReadLine();
        string player2 = Console.ReadLine();
        IList<Card> player1Hand = new List<Card>();
        IList<Card> player2Hand = new List<Card>();
        IList<Card> deck = new List<Card>();
        bool stillPlaying = true;
        string currentCard = "";
        bool validCard = false;

        foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits)))
        {
            foreach (CardRanks rank in Enum.GetValues(typeof(CardRanks)))
            {
                string cardRank = rank.ToString();
                string cardSuit = suit.ToString();
                deck.Add(new Card(cardRank, cardSuit));
            }
        }

        Card[] validCards = new Card[52];
        deck.CopyTo(validCards, 0);

        while (stillPlaying)
        {
            currentCard = Console.ReadLine();
            string[] arguments = currentCard.Split(' ');
            Card card = new Card(arguments[0], arguments[2]);

            if (player1Hand.Count < 5)
            {
                try
                {
                    if (cardExists(validCards, card))
                    {
                        validCard = true;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }

                try
                {
                    if (cardInDeck(deck, card) && validCard)
                    {
                        player1Hand.Add(card);
                        deck.RemoveAll(c => c.CardPower)
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Card is not in the deck.");
                }
              
            }
            else if (player2Hand.Count < 5)
            {

                try
                {
                    if (cardInDeck(deck, card))
                    {
                        validCard = true;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Card is not in the deck.");
                }
                try
                {
                    if (cardExists(validCards, card) && validCard)
                    {
                        player2Hand.Add(card);
                        int indexToRemove = deck.IndexOf(card);
                        deck.RemoveAt(indexToRemove);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("No such card exists.");
                }
            }
            else if (player1Hand.Count == 5 && player2Hand.Count == 5)
            {
                stillPlaying = false;
            }
        }

        int hand1Power = 0;
        Card winning1 = new Card("Ace", "Clubs");
        int hand2Power = 0;
        Card winning2 = new Card("Ace", "Clubs");

        foreach (Card card1 in player1Hand)
        {
            if (card1.CardPower > hand1Power)
            {
                hand1Power = card1.CardPower;
                winning1 = card1;
            }
        }
        foreach (Card card2 in player2Hand)
        {
            if (card2.CardPower > hand2Power)
            {
                hand2Power = card2.CardPower;
                winning2 = card2;
            }
        }

        if (hand1Power > hand2Power)
        {
            Console.WriteLine($"{player1} wins with {winning1}");
        }
        else
        {
            Console.WriteLine($"{player2} wins with {winning2}");
        }

        Console.WriteLine();

        Console.ReadLine();
    }

    private static bool cardExists(Card[] validCards, Card card)
    {
        bool isThere = false;
        foreach (Card currentCard in validCards)
        {
            if (currentCard.CardPower == card.CardPower)
            {
                isThere = true;
            }
        }
        return isThere;
    }
    private static bool cardInDeck(IList<Card> deck, Card card)
    {
        bool isThere = false;
        foreach (Card currentCard in deck)
        {
            if (currentCard.CardPower == card.CardPower)
            {
                isThere = true;
            }
        }
        return isThere;
    }
}

