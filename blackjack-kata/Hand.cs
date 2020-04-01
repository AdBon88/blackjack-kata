using System.Reflection.Metadata;
using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Hand
    {
        public List<Card> Cards {get;} = new List<Card>();
        private int _value = 0;

        public Hand(List<Card> newHand)
        {
            Cards = newHand;
            _value += CalculateValue();
        }
        
        public int CalculateValue()
        {
            int sum = 0;
            List<Card> aces = new List<Card>();

            foreach (Card card in Cards)
            {
                switch(card.Rank)
                {
                    case CardRank.ACE:
                        aces.Add(card);
                        break;
                    case CardRank.JACK:
                    case CardRank.QUEEN:
                    case CardRank.KING:
                        sum += 10;
                        break;
                    default:
                        sum += (int)card.Rank;
                        break;
                }
            }
            foreach (Card ace in aces)
            {
                if(sum > 10)
                    sum++;
                else
                    sum += 11;
            }
            return sum;
        }
    }
}