using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Deck
    {
        public List<Card> Cards {get;} = new List<Card>();

        public Deck()
        {
            foreach ( CardRank rank in (CardRank[]) Enum.GetValues(typeof(CardRank)) )
            {
                foreach ( CardSuit suit in (CardSuit[]) Enum.GetValues(typeof(CardSuit)) )
                {
                    Cards.Add(new Card(rank, suit));
                }
            }
        }

        public Card DrawCard()
        {
            Random random = new Random();
            int indexOfDrawnCard = random.Next(0, Cards.Count); //0 is inclusive lower bound limit, 52 is exclusive upper bound limit
            Card card = Cards[indexOfDrawnCard];
            Cards.RemoveAt(indexOfDrawnCard);
            return card;
        }
    }   
}