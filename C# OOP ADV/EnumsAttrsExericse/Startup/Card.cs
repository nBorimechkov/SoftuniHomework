using System;

public class Card : IComparable<Card>
{
    public Card(string rank, string suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public string Rank { get; set; }
    public string Suit { get; set; }
    public int CardPower { get { return GetCardPower(); } }

    private int GetCardPower()
    {

        CardSuits cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), this.Suit);
        CardRanks cardRank = (CardRanks)Enum.Parse(typeof(CardRanks), this.Rank);
        return (int)cardRank + (int)cardSuit;
    }


    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.CardPower}";
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower() > other.GetCardPower() ? 1 : -1;
    }
}

