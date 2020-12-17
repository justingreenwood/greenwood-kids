using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Serialization;

namespace YourFarts
{
    class Program
    {
        static Random chance = new Random();
        
        
        static void Main(string[] args)
        {



            //int echoice = chance.Next(3);
            //int aroll = chance.Next(6);
            //int roll = chance.Next(6);
            bool Apple = false;
            bool banana = false;
            int ehealth = 3;
            int phealth = 3;
            Console.WriteLine("Welcome to Boring Games.");
            Console.WriteLine("What game do you want to play.");
            RorD:
            Console.WriteLine("(R)ock paper scissors, or (D)ice?");
            var Letter = Console.ReadLine();
            Letter = Letter.ToUpper();
            if (Letter == "R")
            {
                Apple = true;                
            }
            else if (Letter == "D")
            {
                banana = true;
            }
            else
            {
                Console.WriteLine("That is not an answer.");
                goto RorD;
            }

            while (Apple == true)
            {
                int echoice = chance.Next(3)+1;
                Console.WriteLine("Welcome to Rock Paper Scissors.");
                some:
                Console.WriteLine("What do you choose (R)ock, (P)aper, or (S)cissors?");
                var choice = Console.ReadLine();
                choice = choice.ToUpper();
                if (choice == "R")
                {
                    
                    //goto some;
                }
                else if (choice == "P")
                {
                    //goto some;
                }
                else if (choice == "S")
                {
                    //goto some;
                }
                else
                    goto some;


                if (choice == "R" && echoice == 1)
                {
                    Console.WriteLine("You win round.");
                    ehealth--;
                }
                else if (choice == "P" && echoice == 2)
                {
                    Console.WriteLine("You win round.");
                    ehealth--;
                }
                else if (choice == "S" && echoice == 3)
                {
                    Console.WriteLine("You win round.");
                    ehealth--;
                }
                else if (choice == "R" && echoice == 2 )
                {
                    Console.WriteLine("It was a tie.");
                }
                else if (choice == "P" && echoice == 3)
                {
                    Console.WriteLine("It was a tie.");
                }
                else if (choice == "S" && echoice == 1)
                {
                    Console.WriteLine("It was a tie.");
                }

                else
                {
                    Console.WriteLine("You lose round.");
                    phealth--;
                }

                if (phealth == 0)
                {
                    Console.WriteLine("You Lose.");
                    break;
                }
                else if (ehealth == 0)
                {
                    Console.WriteLine("You Win.");
                    break;
                }
            }

            while (banana == true)
            {
                int aroll = chance.Next(6)+1;
                int roll = chance.Next(6)+1;
                Console.WriteLine("You roll");
                Console.WriteLine("You rolled a " + aroll);
                Thread.Sleep(1500);
                Console.WriteLine("The enemy rolled a " + roll);
                Thread.Sleep(1500);
                if (aroll > roll)
                {
                    Console.WriteLine("You win the round.");
                    ehealth--;
                }
                else if (aroll < roll)
                {
                    Console.WriteLine("You lose the round.");
                    phealth--;
                }
                else
                {
                    Console.WriteLine("It was a tie.");
                }

                if (ehealth == 0)
                {
                    Console.WriteLine("You win.");
                    banana = false;
                }
                else if (phealth == 0)
                {
                    Console.WriteLine("You lose");
                    banana = false;
                }


                    

            }

        }
    }
}
