using System;

namespace blackjack_kata
{
    public class Card
    {
        public CardRank Rank { get; }
        public CardSuit Suit { get; }

        public Card (CardRank newRank, CardSuit newSuit) {
            Rank = newRank;
            Suit = newSuit;

        }

        public override string ToString()
        {
            string cardString = "";

            if((int)Rank > 1 && (int)Rank < 11)
                cardString += $"[{(int)Rank}, ";
            else
                cardString += $"['{Rank}', ";

            cardString += $"'{Suit}']";
            
            return cardString;
        }
    }
}
