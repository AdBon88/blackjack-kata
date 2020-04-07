using System;
using System.Runtime;
using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class ParticipantTests
    {

        [Fact]
        public void Participant_CanDrawFirstHand_GetTwoCards(){

            Participant player = new Participant(ParticipantType.PLAYER);
            Deck deck = new Deck();

            Hand newHand = new Hand(player.DrawFirstTwoCards(deck));

            Assert.True(newHand.Cards.Count == 2);

        }

        [Fact]
        public void Participant_Hit_DrawsOneCard(){

            Participant player = new Participant(ParticipantType.PLAYER);
            Deck deck = new Deck();
            player.Hand = new Hand(player.DrawFirstTwoCards(deck));
            player.Hit(deck);

            const int expected = 3;
            int actual = player.Hand.Cards.Count;


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Participant_CheckForBust_BustsIfHandSumExceeds21(){

            Deck deck = new Deck();
            Participant player = new Participant(ParticipantType.PLAYER);
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.KING, CardSuit.DIAMOND), new Card(CardRank.ACE, CardSuit.DIAMOND)}; //hand at 21
            player.Hand = new Hand(cards);
            player.Hit(deck);

            Assert.True(player.HasBusted);
        }

        [Fact]
        public void Participant_CheckForBust_NoBustIfHandSumLessThan22()
        {

            Participant player = new Participant(ParticipantType.PLAYER);
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.KING, CardSuit.DIAMOND), new Card(CardRank.ACE, CardSuit.DIAMOND)};// hand at 21

            player.Hand = new Hand(cards);
            player.CheckForBust();

            Assert.False(player.HasBusted);
        }

    }
}