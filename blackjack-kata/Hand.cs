using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Hand
    {
        public List<Card> Cards {get;} = new List<Card>();
        

        public Hand(List<Card> newHand)
        {
            Cards = newHand;
        }
        
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (Card card in Cards)
                {
                    sum += (int)card.Rank;
                }
                return sum;
            }
        }

    }

    
}