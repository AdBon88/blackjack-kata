using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Participant
    {
        public Hand Hand {get; set;}
        public ParticipantType Type {get;}
        public bool HasStayed {get; set;} = false;
        public bool HasBusted {get; set;} = false;
        public Participant(ParticipantType type)
        {
            Type = type;
        }
        public List<Card> DrawFirstTwoCards(Deck deck)
        {
            
            List<Card> firstTwoCards = new List<Card>();
            firstTwoCards.Add(deck.DrawCard());
            firstTwoCards.Add(deck.DrawCard());

            return firstTwoCards;

        }

        public void Hit(Deck deck)
        {
            Hand.AddCard(deck.DrawCard());
            CheckForBust();
        }

        public void CheckForBust()
        {
            if (Hand.ValueToString() == "Bust!")
                HasBusted = true;
        }
    }
}