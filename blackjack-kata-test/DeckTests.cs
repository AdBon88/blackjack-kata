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
        
        [Fact]
        public void Deck_addCard_addsCardToDeck()
        {
            Deck deck = new Deck();
            deck.AddCard(new Card(CardRank.QUEEN, CardSuit.SPADE));
            Assert.True(deck.Cards.Count == 53);
        }

        [Fact]
        public void Deck_HasNoDuplicateCards_returnsFalseIfContainsDuplicates()
        {
            Deck deck = new Deck();
            deck.AddCard(new Card(CardRank.QUEEN, CardSuit.SPADE));

            Assert.False(deck.HasNoDuplicateCards());
        }

        [Fact]
        public void Deck_HasNoDuplicateCards_returnsTrueIfNoDuplicates()
        {
            Deck deck = new Deck();

            Assert.True(deck.HasNoDuplicateCards());
        }


    }
}