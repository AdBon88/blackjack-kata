using System;
using Xunit;

namespace blackjack_kata
{
    public class DeckTests
    {
        [Fact]
        public void Deck_newDeckHas52Cards()
        {
            Deck newDeck = new Deck();
            const int expected = 52;
            var actual = newDeck.Cards.Count;

            Assert.Equal(expected, actual);
        }
    }
}