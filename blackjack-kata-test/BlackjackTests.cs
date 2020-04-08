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
        public void Blackjack_DealFirstHand_PlayerIsDealtTwoCards(){

            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.DealFirstHand(blackjack.Player); //discuss how I changed method signature

            Assert.True(blackjack.Player.Hand.Cards.Count == 2);

        }

        [Fact]
        public void Blackjack_DealFirstHand_DealerIsDealtTwoCards(){ //Do I need this? essential a duplicate of test at line 24

            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.DealFirstHand(blackjack.Dealer);

            Assert.True(blackjack.Dealer.Hand.Cards.Count == 2);

        }

        [Fact]
        public void BlackJack_DrawCard_Player_AddsCardToPlayerHand()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.DealFirstHand(blackjack.Player);
            blackjack.DrawCard(blackjack.Player);

            //When
            const int expected = 3;
            int actual = blackjack.Player.Hand.Cards.Count;
            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_Drawcard_Dealer_AddsCardToDealerHand()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.DealFirstHand(blackjack.Dealer);
            blackjack.DrawCard(blackjack.Dealer);

            //When
            const int expected = 3;
            int actual = blackjack.Dealer.Hand.Cards.Count;
            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_DrawCardResultToString_OutputsResultOfPlayerCardDrawInCorrectFormat()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            Card cardDrawn = new Card(CardRank.JACK, CardSuit.CLUB);
        
            //When
            const string expected = "You draw ['JACK', 'CLUB']";
            string actual = blackjack.DrawCardResultToString(blackjack.Player, cardDrawn);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_DrawCardResultToString_OutputsResultOfDealerCardDrawInCorrectFormat()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            Card cardDrawn = new Card(CardRank.SEVEN, CardSuit.DIAMOND);
        
            //When
            const string expected = "\nDealer draws [7, 'DIAMOND']";
            string actual = blackjack.DrawCardResultToString(blackjack.Dealer, cardDrawn);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlackJack_playerCanStay_DrawsNoCards()
        {
            //Given
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.DealFirstHand(blackjack.Player);
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
            blackjack.DealFirstHand(blackjack.Player);
            blackjack.Stay();

            Assert.True(blackjack.Player.HasStayed);
        }

        [Fact]
        public void Blackjack_PlayerStatusToString_OutputsHandIfPlayerHasNotBusted()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.TWO, CardSuit.DIAMOND)}; 
            blackjack.Player.Hand = new Hand(cards);

            string expected = $"\nYou are currently at 12";
            expected += $"\nwith the hand ['KING', 'HEART'], [2, 'DIAMOND']";
            
            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_PlayerStatusToString_OutputsBustIfPlayerHasBusted()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.KING, CardSuit.DIAMOND), new Card(CardRank.TWO, CardSuit.DIAMOND)}; 
            blackjack.Player.Hand = new Hand(cards);

            string expected = "\nYou are currently at Bust!";
            expected += $"\nwith the hand ['KING', 'HEART'], ['KING', 'DIAMOND'], [2, 'DIAMOND']";

            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_PlayerStatusToString_OutputsBlackjackIfHandIsBlackJack()
        {
            
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)}; 
            blackjack.Player.Hand = new Hand(cards);

            string expected = "\nYou are currently at Blackjack!";
            expected += $"\nwith the hand ['KING', 'HEART'], ['ACE', 'DIAMOND']";

            string actual = blackjack.PlayerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_DealearStatusToString_OutputsHandIfDealerHasNotBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();

            List<Card> cards = new List<Card>{new Card(CardRank.FOUR, CardSuit.SPADE), new Card(CardRank.ACE, CardSuit.CLUB)}; 
            blackjack.Dealer.Hand = new Hand(cards);

            string expected = $"\nDealer is at 15";
            expected += $"\nwith the hand [4, 'SPADE'], ['ACE', 'CLUB']";
            
            string actual = blackjack.DealerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_DealearStatusToString_OutputsBustIfDealerHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.JACK, CardSuit.CLUB), new Card(CardRank.TEN, CardSuit.SPADE), new Card(CardRank.THREE, CardSuit.HEART)}; 
            blackjack.Dealer.Hand = new Hand(cards);

            string expected = "\nDealer is at Bust!";
            expected += $"\nwith the hand ['JACK', 'CLUB'], [10, 'SPADE'], [3, 'HEART']";

            string actual = blackjack.DealerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_DealearStatusToString_OutputsBlackjackIfHandIsBlackjack()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.QUEEN, CardSuit.SPADE), new Card(CardRank.ACE, CardSuit.HEART)}; 
            blackjack.Dealer.Hand = new Hand(cards);

            string expected = "\nDealer is at Blackjack!";
            expected += $"\nwith the hand ['QUEEN', 'SPADE'], ['ACE', 'HEART']";

            string actual = blackjack.DealerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_DealearStatusToString_OutputsDealerStaysIfHandGreaterThan16AndNotBustOrBlackjack()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            //hand at 22
            List<Card> cards = new List<Card>{new Card(CardRank.SIX, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.SPADE)};
            blackjack.Dealer.Hand = new Hand(cards);

            string expected = "\nDealer is at 17";
            expected += $"\nwith the hand [6, 'HEART'], ['ACE', 'SPADE']";
            expected += "\n\nDealer stays";

            string actual = blackjack.DealerStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_CheckForDealer17_DealerStaysIfHandIs17OrGreater()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> cards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};

            blackjack.Dealer.Hand = new Hand(cards);
            blackjack.CheckForDealer17();

            Assert.True(blackjack.Dealer.HasStayed);
        }

        // [Fact]
        // public void Blackjack_PlayerHandBeatsDealerHand_returnsTrueIfPlayerHandIsGreaterThanDealerHand()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.EIGHT, CardSuit.DIAMOND)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.True(blackjack.PlayerHandBeatsDealerHand());
        // }

        // [Fact]
        // public void Blackjack_PlayerHandBeatsDealerHand_returnsFalseIfPlayerHandIsGreaterThanDealerHand()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.EIGHT, CardSuit.HEART), new Card(CardRank.NINE, CardSuit.DIAMOND)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.NINE, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.False(blackjack.PlayerHandBeatsDealerHand());
        // }

        // [Fact]
        // public void Blackjack_PlayerHandBeatsDealerHand_returnsFalseIfBothHaveBlackjack()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.TEN, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.False(blackjack.PlayerHandBeatsDealerHand());
        // }

        // [Fact]
        // public void Blackjack_PlayerHandBeatsDealerHand_returnsTrueIfPlayerHasBlackJack_DealerHasNonBlackjack21()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.TEN, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.THREE, CardSuit.DIAMOND), new Card(CardRank.EIGHT, CardSuit.CLUB)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.True(blackjack.PlayerHandBeatsDealerHand());
        // }

        // [Fact]
        // public void Blackjack_Dealer_returnsFalseIfDealerHasBlackJack_PlayerHasNonBlackjack21()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.THREE, CardSuit.DIAMOND), new Card(CardRank.EIGHT, CardSuit.CLUB)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.TEN, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.False(blackjack.PlayerHandBeatsDealerHand());
        // }

        // [Fact]
        // public void Blackjack_PlayerHandBeatsDealerHand_returnsTrueIfPlayerHandIsGreaterThanDealerHand()
        // {
        //     Blackjack blackjack = new Blackjack();
        //     blackjack.ResetGame();
        //     List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.EIGHT, CardSuit.DIAMOND)};
        //     List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};
        //     blackjack.Player.Hand = new Hand(playerCards);
        //     blackjack.Dealer.Hand = new Hand(dealerCards);

        //     Assert.True(blackjack.PlayerHandBeatsDealerHand());
        // }
        [Fact]
        public void Blackjack_EndGameStatusAsString_OutputsDealerWinsIfPlayerHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.Player.HasBusted = true;

            const string expected = "\nDealer wins!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_OutputsPlayerWinsIfDealerHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = true;

            const string expected = "\nYou beat the dealer!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_OutputsPlayerWinsIfPlayerHandGreaterThanDealerHand_NeitherHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.EIGHT, CardSuit.DIAMOND)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nYou beat the dealer!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Blackjack_EndGameStatusAsString_OutputsDealerWinsIfDealerHandGreaterThanPlayerHand_NeitherHasBusted()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.TWO, CardSuit.HEART), new Card(CardRank.THREE, CardSuit.DIAMOND)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nDealer wins!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_PlayerHasBlackjackDealerHasNonBlackjack21O_OutputsPlayerWins()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.ACE, CardSuit.DIAMOND)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.FOUR, CardSuit.DIAMOND), new Card(CardRank.SEVEN, CardSuit.DIAMOND)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nYou beat the dealer!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_DealerHasBlackjackPlayerHasNonBlackjack21O_OutputsDealerWins()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.KING, CardSuit.HEART), new Card(CardRank.TWO, CardSuit.DIAMOND),  new Card(CardRank.NINE, CardSuit.DIAMOND)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.JACK, CardSuit.SPADE), new Card(CardRank.ACE, CardSuit.HEART)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nDealer wins!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_DealerPlayerHaveSameHandValueNeitherAreBust_OutputsStandoff()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.JACK, CardSuit.SPADE), new Card(CardRank.TWO, CardSuit.HEART)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.FOUR, CardSuit.SPADE), new Card(CardRank.SIX, CardSuit.CLUB), new Card(CardRank.TWO, CardSuit.SPADE)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nStand off!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Blackjack_EndGameStatusAsString_DealerPlayerBothHaveBlackjack_OutputsStandoff()
        {
            Blackjack blackjack = new Blackjack();
            blackjack.ResetGame();
            List<Card> playerCards = new List<Card>{new Card(CardRank.JACK, CardSuit.SPADE), new Card(CardRank.ACE, CardSuit.HEART)};
            List<Card> dealerCards = new List<Card>{new Card(CardRank.TEN, CardSuit.SPADE), new Card(CardRank.ACE, CardSuit.CLUB)};
            blackjack.Player.Hand = new Hand(playerCards);
            blackjack.Dealer.Hand = new Hand(dealerCards);
            blackjack.Player.HasBusted = false;
            blackjack.Dealer.HasBusted = false;

            const string expected = "\nStand off!";
            string actual = blackjack.EndGameStatusToString();
            
            Assert.Equal(expected, actual);
        }
    }
}
