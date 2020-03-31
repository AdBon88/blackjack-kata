using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class HandTests
    {
        [Fact]
        public void Hand_HandValueEqualsSumOfCardValues()
        {
        //Given
        List<Card> cards = new List<Card>{new Card(CardRank.THREE, CardSuit.CLUB), new Card(CardRank.KING, CardSuit.DIAMOND)};
        Hand hand = new Hand(cards);

        //When
        const int expected = 13;
        int actual = hand.Sum;
        //Then
        Assert.Equal(expected, actual);
        }
    }
}