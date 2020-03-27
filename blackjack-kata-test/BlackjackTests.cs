using System;
using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class BlackJackTests

    {
        [Fact]
    
        public void Card_canCreateCard()
        {
            var expectedRank = CardRank.ACE;
            var expectedSuit = CardSuit.HEARTS;

            Card card = new Card(expectedRank, expectedSuit); 
            var actualRank = card.Rank;
            var actualSuit = card.Suit;
            Assert.Equal(expectedRank, actualRank);
            Assert.Equal(expectedSuit, actualSuit);
        }

        [Theory]
        [InlineData(CardRank.ACE, CardSuit.DIAMONDS, 1)]
        [InlineData(CardRank.TWO, CardSuit.DIAMONDS, 2)]
        [InlineData(CardRank.THREE, CardSuit.HEARTS, 3)]
        [InlineData(CardRank.FOUR, CardSuit.SPADES, 4)]
        [InlineData(CardRank.FIVE, CardSuit.CLUBS, 5)]
        [InlineData(CardRank.SIX, CardSuit.DIAMONDS, 6)]
        [InlineData(CardRank.SEVEN, CardSuit.HEARTS, 7)]
        [InlineData(CardRank.EIGHT, CardSuit.SPADES, 8)]
        [InlineData(CardRank.NINE, CardSuit.CLUBS, 9)]
        [InlineData(CardRank.TEN, CardSuit.DIAMONDS, 10)]
        [InlineData(CardRank.JACK, CardSuit.HEARTS, 11)]
        [InlineData(CardRank.QUEEN, CardSuit.SPADES, 12)]
        [InlineData(CardRank.KING, CardSuit.CLUBS, 13)]
        
        public void Card_cardRankHasCorrectValue(CardRank rank, CardSuit suit, int expected)
        {
            Card card = new Card(rank, suit); 
            var actual = (int)card.Rank;
            Assert.Equal(expected, actual);
        }

        
        [Fact]
        public void Deck_newDeckHas52Cards()
        {
            Deck newDeck = new Deck();

            List<Card> cards = newDeck.Cards;
            const int expected = 52;
            var actual = newDeck.Cards.Count;

            Assert.Equal(expected, actual);
        }
    }
}
