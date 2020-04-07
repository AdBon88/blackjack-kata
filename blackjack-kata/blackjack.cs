using System;
using System.Collections.Generic;

namespace blackjack_kata
{
    public class Blackjack
    {
        public Participant Dealer {get; set;}
        public Participant Player {get; set;}
        public Deck Deck {get; set;}

        public void run()
        {
            displayWelcomeScreenWithOptions();
            ResetGame();
            startGame();
        }
        public void displayWelcomeScreenWithOptions()
        {
            //TODO implement options
            Console.WriteLine("\n##################");
            Console.WriteLine("### BLACKJACK! ###");
            Console.WriteLine("##################\n");
            Console.WriteLine("Welcome to blackjack!");
        }

        public void ResetGame()
        {
            Dealer = new Participant(ParticipantType.DEALER);
            Player = new Participant(ParticipantType.PLAYER);
            Deck = new Deck();
        }

        public void startGame() //how totest this??
        {
            dealFirstHand();
            
            while(!Player.HasStayed && !Player.HasBusted)
            {
                Console.WriteLine(PlayerStatusToString());
                int input = GetInputForHitOrStay();
                if (input == 0)
                    Player.HasStayed = true;
                else
                    DrawCard();
            }
            Console.WriteLine(PlayerStatusToString());
            Console.WriteLine(EndGameStatusToString());
        }

        public void dealFirstHand()
        {
            List<Card> firstHand = Player.DrawFirstTwoCards(Deck);
            Player.Hand = new Hand(firstHand);
        }

        // discuss
        public string PlayerStatusToString()
        {
            string status = $"\nYou are currently at {Player.Hand.ValueToString()}";
            status += $"\nwith the hand {Player.Hand.ToString()}";
    
            return status;
        }

        public int GetInputForHitOrStay() //untestable
        {
            int input;
            
            Console.WriteLine("\nHit or stay? (Hit = 1, Stay = 0)");
            while ((!Int32.TryParse(Console.ReadLine(), out input)) || input != 1 && input != 0) {
                Console.WriteLine($"Invalid selection! Please enter 1 to hit or 0 to stay!");
            }

            return input;
        }

        public void DrawCard(){
            Player.Hit(Deck);
            int totalCardsInHand = Player.Hand.Cards.Count;
            Card cardDrawn = Player.Hand.Cards[totalCardsInHand - 1];

            Console.WriteLine($"You draw {cardDrawn.ToString()}"); //test output also? just get it to return a string
        }

        public void Stay()
        {
            Player.HasStayed = true;
        }
        
        public string EndGameStatusToString()
        {
            string endGameStatus = "\nDealer Wins!";
            return endGameStatus;
        }

    }
}