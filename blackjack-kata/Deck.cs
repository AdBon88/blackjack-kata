using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Deck
    {
        public List<Card> Cards {get;} = new List<Card>();

        public Deck(){
            Cards.Add(new Card(CardRank.ACE, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.ACE, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.ACE, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.ACE, CardSuit.SPADES));

            Cards.Add(new Card(CardRank.TWO, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.TWO, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.TWO, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.TWO, CardSuit.SPADES));

            Cards.Add(new Card(CardRank.THREE, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.THREE, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.THREE, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.THREE, CardSuit.SPADES));

            Cards.Add(new Card(CardRank.FOUR, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.FOUR, CardSuit.SPADES));

            Cards.Add(new Card(CardRank.FIVE, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.FIVE, CardSuit.SPADES));
            
            Cards.Add(new Card(CardRank.SIX, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.SIX, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.SIX, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.SIX, CardSuit.SPADES));
                        
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.SEVEN, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.EIGHT, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.NINE, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.NINE, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.NINE, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.NINE, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.TEN, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.TEN, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.TEN, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.TEN, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.JACK, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.JACK, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.JACK, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.JACK, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.QUEEN, CardSuit.SPADES));  
                        
            Cards.Add(new Card(CardRank.KING, CardSuit.HEARTS));
            Cards.Add(new Card(CardRank.KING, CardSuit.DIAMONDS));
            Cards.Add(new Card(CardRank.KING, CardSuit.CLUBS));
            Cards.Add(new Card(CardRank.KING, CardSuit.SPADES));  
        }

    }



}