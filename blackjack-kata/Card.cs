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

        // //is this needed?
        public override bool Equals ( object obj )
        {
            return Equals(obj as Card);
        }

        public bool Equals(Card anotherCard){
            
            if (Rank == anotherCard.Rank && Suit == anotherCard.Suit)
                return true;
            else
                return false;
        }
    }
}
