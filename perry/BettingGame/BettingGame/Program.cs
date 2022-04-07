using System;

namespace BettingGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            double odds = .75;
            Guys player = new Guys() { Money = 100, Name = "The Player" };

            Console.WriteLine("Welcome to the betting game. The odds are 0.75.");

            while (player.Money > 0)
            {
                player.WriteMyInfo();

                Console.Write("How much money do you want to bet: ");
                string amountBetted = Console.ReadLine();

                if (int.TryParse(amountBetted, out int amount))
                {
                    int pot = player.GiveMoney(amount) * 2;
                    if (pot > 0)
                    {                        
                        if (random.NextDouble() > odds)
                        {

                            Console.WriteLine("You win " + pot + " dollars.");
                            player.ReceiveMoney(pot);

                        }
                        else
                        {
                            Console.WriteLine("You were unlucky.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid number. ");
                    }

                }
                else
                {
                    Console.WriteLine("That is not a number. ");
                }


            }
            Console.WriteLine("The house always wins.");
        }
    }
}
