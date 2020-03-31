using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Dealer
    {
        public Dealer()
        {

        }
        public List<Card> DealFirstTwoCards(Deck deck)
        {
            
            List<Card> firstTwoCards = new List<Card>();
            firstTwoCards.Add(deck.DrawCard());
            firstTwoCards.Add(deck.DrawCard());

            return firstTwoCards;

        }
    }
}