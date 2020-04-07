using System;
using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class CardTests
    {
        [Fact]
        public void Card_canCreateCard()
        {
            var expectedRank = CardRank.ACE;
            var expectedSuit = CardSuit.HEART;

            Card card = new Card(expectedRank, expectedSuit); 
            var actualRank = card.Rank;
            var actualSuit = card.Suit;
            Assert.Equal(expectedRank, actualRank);
            Assert.Equal(expectedSuit, actualSuit);
        }

        [Theory]
        [InlineData(CardRank.ACE, CardSuit.DIAMOND, 1)]
        [InlineData(CardRank.TWO, CardSuit.DIAMOND, 2)]
        [InlineData(CardRank.THREE, CardSuit.HEART, 3)]
        [InlineData(CardRank.FOUR, CardSuit.SPADE, 4)]
        [InlineData(CardRank.FIVE, CardSuit.CLUB, 5)]
        [InlineData(CardRank.SIX, CardSuit.DIAMOND, 6)]
        [InlineData(CardRank.SEVEN, CardSuit.HEART, 7)]
        [InlineData(CardRank.EIGHT, CardSuit.SPADE, 8)]
        [InlineData(CardRank.NINE, CardSuit.CLUB, 9)]
        [InlineData(CardRank.TEN, CardSuit.DIAMOND, 10)]
        [InlineData(CardRank.JACK, CardSuit.HEART, 11)]
        [InlineData(CardRank.QUEEN, CardSuit.SPADE, 12)]
        [InlineData(CardRank.KING, CardSuit.CLUB, 13)]
        
        public void Card_cardRankHasCorrectValue(CardRank rank, CardSuit suit, int expected)
        {
            Card card = new Card(rank, suit); 
            var actual = (int)card.Rank;
            Assert.Equal(expected, actual);
        } 
        
        [Theory]
        [InlineData(CardRank.ACE, CardSuit.HEART)]
        [InlineData(CardRank.TWO, CardSuit.SPADE)]
        [InlineData(CardRank.KING, CardSuit.CLUB)]
        public void Card_pairWithSameSuitAndRankAreEqual(CardRank rank, CardSuit suit)
        {
            Card card1 = new Card(rank, suit);
            Card card2 = new Card(rank, suit);

            Assert.True(card1.Rank == card2.Rank && card1.Suit == card2.Suit);
        }

        [Theory]
        [InlineData(CardRank.ACE, CardSuit.HEART, CardRank.TEN, CardSuit.DIAMOND)]
        [InlineData(CardRank.JACK, CardSuit.SPADE, CardRank.JACK, CardSuit.CLUB)]
        [InlineData(CardRank.FIVE, CardSuit.DIAMOND, CardRank.NINE, CardSuit.DIAMOND)]
        public void Card_pairWithDifferentRankOrSuitAreNotEqual(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, CardSuit card2Suit)
        {
            Card card1 = new Card(card1Rank, card1Suit);
            Card card2 = new Card(card2Rank, card2Suit);
    
            Assert.False(card1.Rank == card2.Rank && card1.Suit == card2.Suit);
        }

        [Fact]
        public void Card_canConvertToStringInCorrectFormat()
        {
            Card card = new Card(CardRank.KING, CardSuit.SPADE);

            const string expected = "['KING', 'SPADE']";
            string actual = card.ToString();
            
            Assert.Equal(expected, actual);
        }

    }
}