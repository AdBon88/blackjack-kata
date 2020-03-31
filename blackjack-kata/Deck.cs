using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack_kata
{
    public class Deck
    {
        public List<Card> Cards {get;} = new List<Card>();

        public Deck()
        {
            Cards.Add(new Card(CardRank.ACE, CardSuit.HEART));
            Cards.Add(new Card(CardRank.ACE, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.ACE, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.ACE, CardSuit.SPADE));

            Cards.Add(new Card(CardRank.TWO, CardSuit.HEART));
            Cards.Add(new Card(CardRank.TWO, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.TWO, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.TWO, CardSuit.SPADE));

            Cards.Add(new Card(CardRank.THREE, CardSuit.HEART));
            Cards.Add(new Card(CardRank.THREE, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.THREE, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.THREE, CardSuit.SPADE));

            Cards.Add(new Card(CardRank.FOUR, CardSuit.HEART));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.SPADE));

            Cards.Add(new Card(CardRank.FIVE, CardSuit.HEART));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.SPADE));
            
            Cards.Add(new Card(CardRank.SIX, CardSuit.HEART));
            Cards.Add(new Card(CardRank.SIX, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.SIX, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.SIX, CardSuit.SPADE));
                        
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.HEART));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.HEART));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.NINE, CardSuit.HEART));
            Cards.Add(new Card(CardRank.NINE, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.NINE, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.NINE, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.TEN, CardSuit.HEART));
            Cards.Add(new Card(CardRank.TEN, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.TEN, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.TEN, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.JACK, CardSuit.HEART));
            Cards.Add(new Card(CardRank.JACK, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.JACK, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.JACK, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.HEART));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.SPADE));  
                        
            Cards.Add(new Card(CardRank.KING, CardSuit.HEART));
            Cards.Add(new Card(CardRank.KING, CardSuit.DIAMOND));
            Cards.Add(new Card(CardRank.KING, CardSuit.CLUB));
            Cards.Add(new Card(CardRank.KING, CardSuit.SPADE));  
        }
    }



}