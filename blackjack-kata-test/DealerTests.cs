using System;
using System.Runtime;
using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class DealerTests
    {

        //discuss
        [Fact]
        public void Dealer_CanDealTwoCardHand(){

            Dealer dealer = new Dealer();
            Deck deck = new Deck();

            Hand newHand = new Hand(dealer.DealFirstTwoCards(deck));

            Assert.True(newHand.Cards.Count == 2);

        }
    }
}