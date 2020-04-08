using System.Globalization;
using Microsoft.Win32.SafeHandles;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Hand
    {
        public List<Card> Cards {get;set;} = new List<Card>();

        public Hand(List<Card> newHand)
        {
            Cards = newHand;
        }
        

        public string ValueToString()
        {
            int totalSum = GetValue();

            if (totalSum == 21 && Cards.Count == 2)
                return "Blackjack!";
            else if (totalSum <= 21)
                return totalSum.ToString();
            else
                return "Bust!";
        }
        public int GetValue()
        {
            int sumBeforeAces = 0;
            List<Card> aces = new List<Card>();

            foreach (Card card in Cards)
            {
                switch(card.Rank)
                {
                    case CardRank.JACK:
                    case CardRank.QUEEN:
                    case CardRank.KING:
                        sumBeforeAces += 10;
                        break;
                    case CardRank.ACE:
                        aces.Add(card);
                    break;
                    default:
                        sumBeforeAces += (int)card.Rank;
                        break;
                }
            }
            int totalSum = AddAcesToSum(aces, sumBeforeAces);
            return totalSum;
        }

        private int AddAcesToSum(List<Card> aces, int currentSum){
            
            foreach (Card ace in aces)
            {
                if(currentSum > 10)
                    currentSum++;
                else
                    currentSum += 11;
            }
            return currentSum;
        }

        public override string ToString()
        {
            string handString = "";
            int count = 1;
            foreach (Card card in Cards)
            {
                handString += card.ToString();
                if (count < Cards.Count)
                    handString += ", ";
                count ++;
            } 

            return handString;
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }
    }
}