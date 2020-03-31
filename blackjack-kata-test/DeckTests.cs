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
        public void Deck_HasNoDuplicateCards()
        {
            Deck deck = new Deck();
            bool deckHasNoDuplicateCards = true;

            for (int currentCard = 0; currentCard < deck.Cards.Count; currentCard++)
            {
                for(int nextCard = currentCard + 1; nextCard < deck.Cards.Count; nextCard ++)
                {
                    if ( deck.Cards[currentCard].Suit == deck.Cards[nextCard].Suit && deck.Cards[currentCard].Rank == deck.Cards[nextCard].Rank){
                        deckHasNoDuplicateCards = false;
                        break;
                    }
                }
            }

            Assert.True(deckHasNoDuplicateCards);
        }

    }
}