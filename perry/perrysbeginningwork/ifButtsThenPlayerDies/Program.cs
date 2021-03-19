using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifButtsThenPlayerDies
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your score: ");
            string scoreText = Console.ReadLine();
            int score = Convert.ToInt32(scoreText);

            if (score == 100)
            {
                Console.WriteLine("You got an A+.");
            }
            else if (score != 99)
            {
                Console.WriteLine("You did not get 99.");
            }
            else if(score >= 90)
            {
                Console.WriteLine("You got an A.");
            }
            else if(score < 60)
            {
                Console.WriteLine("You Failed.");
            }
            else if (score == 0)            
                Console.WriteLine("You purposefully failed.");           
            else            
                Console.WriteLine("That is a boring score.");

            int pointsToPass = 93;


            bool levelIsComplete;
            if(!(score < pointsToPass))
            {
                levelIsComplete = true;
            }
            else
            {
                levelIsComplete = false;
            }

            if(!levelIsComplete)
            {
                Console.WriteLine("You have not beaten the level.");
            }
            else
            {
                Console.WriteLine("You have beaten the level.");
            }

            Console.WriteLine("Type a number to see if it is odd or even. ");
            string oddEvenString = Console.ReadLine();
            int oddEven = Convert.ToInt32(oddEvenString);
            int answer = oddEven % 2;
            if(oddEven == 0)
            {
                Console.WriteLine(oddEven + " is not either odd or even.");
            }
            if (answer == 1)
            {
                Console.WriteLine($"{oddEven} is odd.");
            }
            else
            {
                Console.WriteLine($"{oddEven} is even.");
            }

            int armor = 50;
            int shield = 20;

            if (shield <= 0 || armor <= 0)
            {
                Console.WriteLine("You are still alive.");
            }
            else if (shield <= 0 && armor <= 0)
            {
                Console.WriteLine("You lose.");
            }

            if(shield <= 0)
            {
                if(armor <= 0)
                {
                    Console.WriteLine("You Lose. :(");
                }
                else
                {
                    Console.WriteLine("You lost your sheild, but you are still alive.");
                }
            }

            Console.WriteLine("Type a number. ");
            string number1 = Console.ReadLine();
            int Number1 = Convert.ToInt32(number1);

            Console.WriteLine("Type another number. ");
            string number2 = Console.ReadLine();
            int Number2 = Convert.ToInt32(number2);

            if((Number1 < 0 && Number2 < 0) || (Number1 > 0 && Number2 > 0))
            {
                Console.WriteLine("The answer is positive.");
            }
            else
            {
                Console.WriteLine("The answer is negative.");
            }

            Console.WriteLine((score > 70) ? "You passed." : "You failed.");

            Console.ReadKey();
        }
    }
}
