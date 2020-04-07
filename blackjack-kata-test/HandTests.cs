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
        const string expected = "8";
        string actual = hand.ValueToString();
        //Then
        Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.KING, CardSuit.DIAMOND, CardRank.TEN, CardSuit.HEART, "20")]
        [InlineData(CardRank.QUEEN, CardSuit.DIAMOND, CardRank.FIVE, CardSuit.CLUB, "15")]
        [InlineData(CardRank.JACK, CardSuit.SPADE, CardRank.QUEEN, CardSuit.SPADE, "20")]
        public void Hand_HandValueIsSumOfCardValues_HasFaceCardsNoAces(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, CardSuit card2Suit, string expected)
        {
            //Given
            List<Card> cards = new List<Card>{new Card(card1Rank, card1Suit), new Card(card2Rank, card2Suit)};
            Hand hand = new Hand(cards);

            //When
            string actual = hand.ValueToString();
            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.ACE, CardSuit.DIAMOND, CardRank.TEN, CardSuit.HEART, CardRank.FIVE, CardSuit.SPADE, "16")]
        [InlineData(CardRank.ACE, CardSuit.DIAMOND, CardRank.FOUR, CardSuit.CLUB, CardRank.SIX, CardSuit.HEART, "Blackjack!")]

        public void Hand_HandValueIsSumOfCardValues_HasFaceCardsAndAces(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, 
            CardSuit card2Suit, CardRank card3Rank, CardSuit card3Suit, string expected)
        {
        //Given
        List<Card> cards = new List<Card>{new Card(card1Rank, card1Suit), new Card(card2Rank, card2Suit), new Card(card3Rank, card3Suit)};
        Hand hand = new Hand(cards);

        //When
        string actual = hand.ValueToString();
        Assert.Equal(expected, actual);
        }

        [Fact]
        public void Hand_HandofTwoAcesOnly_equalsTwelve()
        {
        //Given
        List<Card> cards = new List<Card>{new Card(CardRank.ACE, CardSuit.CLUB), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        Hand hand = new Hand(cards);

        //When
        const string expected = "12";
        string actual = hand.ValueToString();
        //Then
        Assert.Equal(expected, actual);
        }

        [Fact]
        public void Hand_canConvertSingleCardtoStringInCorrectFormat_FaceCard()
        {
        //Given
        List<Card> cards = new List<Card>{new Card(CardRank.QUEEN, CardSuit.SPADE)};
        Hand hand = new Hand(cards);
        //When
        const string expected = "['QUEEN', 'SPADE']";
        string actual = hand.ToString();
        //Then
        Assert.Equal(expected, actual);
        }

        [Fact]
        public void Hand_canConvertSingleCardtoStringInCorrectFormat_numberCard()
        {
        //Given
        List<Card> cards = new List<Card>{new Card(CardRank.FOUR, CardSuit.HEART)};
        Hand hand = new Hand(cards);
        //When
        const string expected = "[4, 'HEART']";
        string actual = hand.ToString();
        //Then
        Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(CardRank.ACE, CardSuit.CLUB, CardRank.FIVE, CardSuit.DIAMOND, CardRank.KING, CardSuit.HEART, CardRank.ACE, CardSuit.SPADE,
            "['ACE', 'CLUB'], [5, 'DIAMOND'], ['KING', 'HEART'], ['ACE', 'SPADE']")]
        [InlineData(CardRank.TWO, CardSuit.HEART, CardRank.JACK, CardSuit.CLUB, CardRank.FOUR, CardSuit.DIAMOND, CardRank.QUEEN, CardSuit.DIAMOND,
            "[2, 'HEART'], ['JACK', 'CLUB'], [4, 'DIAMOND'], ['QUEEN', 'DIAMOND']")]        
        public void Hand_canConvertMultipleCardsToStringInCorrectFormat_allTypes(CardRank card1Rank, CardSuit card1Suit, CardRank card2Rank, 
            CardSuit card2Suit, CardRank card3Rank, CardSuit card3Suit, CardRank card4Rank, CardSuit card4Suit, string expected)
        {
            //Given
            List<Card> cards = new List<Card>{new Card(card1Rank, card1Suit), new Card(card2Rank, card2Suit), new Card(card3Rank, card3Suit), new Card(card4Rank, card4Suit)};
            Hand hand = new Hand(cards);

            //When
            string actual = hand.ToString();
            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Hand_CanAddCard()
        {
            //Given
            List<Card> cards = new List<Card>{new Card(CardRank.FOUR, CardSuit.HEART), new Card(CardRank.TWO, CardSuit.DIAMOND)};
            Hand hand = new Hand(cards);
            //When
            hand.AddCard(new Card(CardRank.TEN, CardSuit.CLUB));
            //Then
            Assert.True(hand.Cards.Count == 3);
        }
    }
}