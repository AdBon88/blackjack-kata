using System;
using System.Collections.Generic;
using Xunit;

namespace blackjack_kata
{
    public class BlackJackTests

    {      
        [Fact]
        //refactor to two tests of AssertEqual
        public void Blackjack_ResetGame_CreatesNewPlayerAndDealer()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            
            //When
            blackjack.ResetGame();
            //Then
            Assert.True(blackjack.Dealer.Type == ParticipantType.DEALER && blackjack.Player.Type == ParticipantType.PLAYER);
        }

        [Fact]
        public void Blackjack_DealFirstHand_PlayerIsDealthtwoCards(){

            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.dealFirstHand();

            Assert.True(blackjack.Player.Hand.Cards.Count == 2);

        }


        [Fact]
        public void BlackJack_playerCanHit_AddsCardToHand()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.dealFirstHand();
            blackjack.DrawCard();

            //When
            const int expected = 3;
            int actual = blackjack.Player.Hand.Cards.Count;
            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_playerCanStay_DrawsNoCards()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.dealFirstHand();
            blackjack.Stay();

            //When
            const int expected = 2;
            int actual = blackjack.Player.Hand.Cards.Count;

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_playerCanStay_HasStayed()
        {

            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.dealFirstHand();
            blackjack.Stay();

            Assert.True(blackjack.Player.HasStayed);
        }

        [Fact]
        public void Blackjack_OutputPlayerStatus_OutputsHandIfPlayerHasNotBusted()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.dealFirstHand();

            string expected = $"\nYou are currently at {blackjack.Player.Hand.ValueToString()}";
            expected += $"\nwith the hand {blackjack.Player.Hand.ToString()}";
            
            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_OutputPlayerStatus_OutputsBustIfPlayerHasBusted()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.KING, CardSuit.DIAMOND), new Card(CardRank.TWO, CardSuit.DIAMOND)}; 
            blackjack.Player.Hand = new Hand(cards);

            string expected = "\nYou are currently at Bust!";
            expected += $"\nwith the hand {blackjack.Player.Hand.ToString()}";

            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_OutputPlayerStatus_OutputsBlackjackIfHandIsBlackJack()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)}; 
            blackjack.Player.Hand = new Hand(cards);

            string expected = "\nYou are currently at Blackjack!";
            expected += $"\nwith the hand {blackjack.Player.Hand.ToString()}";

            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_OutputEndGameStatus_OutputsDealerWinsIfPlayerHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.Player.HasBusted = true;

            const string expected = "\nDealer Wins!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

    }
}
