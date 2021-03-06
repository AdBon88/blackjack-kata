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
            displayWelcome();
            ResetGame();
            StartGame();
        }
        public void displayWelcome()
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

        public void StartGame() //untested
        {
            ProcessPlayerTurns();
            if(Player.HasStayed)
                ProcessDealerTurns();

            Console.WriteLine(EndGameStatusToString());
        }

        public void ProcessPlayerTurns() //untested
        {
            DealFirstHand(Player);
            
            while(!Player.HasStayed && !Player.HasBusted)
            {
                Console.WriteLine(PlayerStatusToString());
                int input = GetInputForHitOrStay();
                if (input == 0)
                    Player.HasStayed = true;
                else
                DrawCard(Player);
            }

            Console.WriteLine(PlayerStatusToString());
        }

        public void ProcessDealerTurns() //untested
        {
            DealFirstHand(Dealer);

            while(!Dealer.HasStayed && !Dealer.HasBusted)
            {
                Console.WriteLine(DealerStatusToString());
                DrawCard(Dealer);
                CheckForDealer17();
            }
            Console.WriteLine(DealerStatusToString());
        }

        public void DealFirstHand(Participant activeParticipant)
        {
            List<Card> firstHand = activeParticipant.DrawFirstTwoCards(Deck);
            activeParticipant.Hand = new Hand(firstHand);
        }
        public string PlayerStatusToString()
        {
            string output = $"\nYou are currently at {Player.Hand.ValueToString()}";
            output += $"\nwith the hand {Player.Hand.ToString()}";
    
            return output;
        }

        public string DealerStatusToString()
        {
            string output = $"\nDealer is at {Dealer.Hand.ValueToString()}";
            output += $"\nwith the hand {Dealer.Hand.ToString()}";

            if (Dealer.Hand.GetValue() >= 17 && Dealer.Hand.GetValue() < 21)
                output +="\n\nDealer stays";
    
            return output;
        }

        public int GetInputForHitOrStay() //untested
        {
            int input;
            
            Console.WriteLine("\nHit or stay? (Hit = 1, Stay = 0)");
            while ((!Int32.TryParse(Console.ReadLine(), out input)) || input != 1 && input != 0) {
                Console.WriteLine($"Invalid selection! Please enter 1 to hit or 0 to stay!");
            }

            return input;
        }

        public void DrawCard(Participant activeParticipant){
            activeParticipant.Hit(Deck);
            int totalCardsInHand = activeParticipant.Hand.Cards.Count;
            Card cardDrawn = activeParticipant.Hand.Cards[totalCardsInHand - 1];

            Console.WriteLine(DrawCardResultToString(activeParticipant, cardDrawn));
        }

        public String DrawCardResultToString(Participant activeParticipant, Card cardDrawn)
        {
            string output = "";
            if(activeParticipant.Type == ParticipantType.PLAYER)
                output = $"You draw {cardDrawn.ToString()}";
            else
                output = $"\nDealer draws {cardDrawn.ToString()}";
            return output;
        }

        public void Stay()
        {
            Player.HasStayed = true;
        }
        
        public void CheckForDealer17()
        {
            if (Dealer.Hand.GetValue() >= 17 && Dealer.Hand.GetValue() <= 21)
                Dealer.HasStayed = true;
        }
        
        public string EndGameStatusToString()
        {
            string output = "";

            if(Dealer.HasBusted && !Player.HasBusted)
                output = "\nYou beat the dealer!";
            else if(!Dealer.HasBusted && Player.HasBusted)
                output = "\nDealer wins!";
            else if(PlayerHandBeatsDealerHand())
                output = "\nYou beat the dealer!";
            else if (DealerHandBeatsPlayerHand())
                output = "\nDealer wins!";
            else
                output = "\nStand off!";
    
            return output;
        }

        private bool PlayerHandBeatsDealerHand()
        {
            if(Player.Hand.GetValue() > Dealer.Hand.GetValue())
                return true;
            else if (Player.Hand.ValueToString() == "Blackjack!" && Dealer.Hand.ValueToString() != "Blackjack!")
                return true;
            else
                return false;
        }

        private bool DealerHandBeatsPlayerHand()
        {
            if(Dealer.Hand.GetValue() > Player.Hand.GetValue())
                return true;
            else if (Dealer.Hand.ValueToString() == "Blackjack!" && Player.Hand.ValueToString() != "Blackjack!")
                return true;
            else
                return false;
        }
    }
}