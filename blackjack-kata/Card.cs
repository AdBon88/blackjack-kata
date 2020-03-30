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
          //throw new NotImplementedException();
        
        }

        public bool isDuplicateOf(Card anotherCard){
            
            if (Rank == anotherCard.Rank && Suit == anotherCard.Suit)
                return true;
            else
                return false;
        }
    }
}
