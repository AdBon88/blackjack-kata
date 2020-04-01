using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class HandTests
    {
        [Fact]
        public void Hand_HandValueIsSumOfCardValues_NoAcesOrFaceCards()
        {
        //Given
        List<Card> cards = new List<Card>{new Card(CardRank.THREE, CardSuit.CLUB), new Card(CardRank.FIVE, CardSuit.DIAMOND)};
        Hand hand = new Hand(cards);

        //When
        const int expected = 8;
        int actual = hand.CalculateValue();
        //Then
        Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.KING, CardSuit.DIAMOND, CardRank.TEN, CardSuit.HEART, 20)]
        [InlineData(CardRank.QUEEN, CardSuit.DIAMOND, CardRank.FIVE, CardSuit.CLUB, 15)]
        [InlineData(CardRank.JACK, CardSuit.SPADE, CardRank.QUEEN, CardSuit.SPADE, 20)]
        public void Hand_HandValueIsSumOfCardValues_HasFaceCardsNoAces(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, CardSuit card2Suit, int expected)
        {
        //Given
        List<Card> cards = new List<Card>{new Card(card1Rank, card1Suit), new Card(card2Rank, card2Suit)};
        Hand hand = new Hand(cards);

        //When
        int actual = hand.CalculateValue();
        //Then
        Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.ACE, CardSuit.DIAMOND, CardRank.TEN, CardSuit.HEART, CardRank.FIVE, CardSuit.SPADE, 16)]
        [InlineData(CardRank.ACE, CardSuit.DIAMOND, CardRank.FOUR, CardSuit.CLUB, CardRank.SIX, CardSuit.HEART, 21)]

        public void Hand_HandValueIsSumOfCardValues_HasFaceCardsAndAces(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, 
            CardSuit card2Suit, CardRank card3Rank, CardSuit card3Suit, int expected)
        {
        //Given
        List<Card> cards = new List<Card>{new Card(card1Rank, card1Suit), new Card(card2Rank, card2Suit), new Card(card3Rank, card3Suit)};
        Hand hand = new Hand(cards);

        //When
        int actual = hand.CalculateValue();
        //Then
        Assert.Equal(expected, actual);
        }


    }
}