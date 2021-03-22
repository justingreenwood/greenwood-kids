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
            //-oguklrd78o6yro7rftg89-py-;io;ugydrs3qa34q6-0809767scxa23cg,l;[-=ut86f5vs3qacdrfmhym9-=.0[k

            int choice = 4;

            if (choice == 1)
                Console.WriteLine("Stupid!");
            else if (choice == 2)
                Console.WriteLine("You Suck!");
            else if (choice == 3)
                Console.WriteLine("You are trash.");
            else if (choice == 4)
                Console.WriteLine("You win 1,000,000 dollars");
            else if (choice == 5)
                Console.WriteLine("That is the wrong answer.");
            else
                Console.WriteLine("Whatever");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Stupid!");
                    break;
                case 2:
                    Console.WriteLine("You Suck!");
                    break;
                case 3:
                    Console.WriteLine("You are trash.");
                    break;
                case 4:
                    Console.WriteLine("You win 1,000,000 dollars");
                    break;
                case 5:
                    Console.WriteLine("That is the wrong answer.");
                    break;
                default:
                    Console.WriteLine("Whatever");
                    break;
            }


               Console.WriteLine("Enter a number: ");
            string number01 = Console.ReadLine();
            int Number01 = Convert.ToInt32(number01);
            Console.WriteLine("Enter another number: ");
            string number02 = Console.ReadLine();
            int Number02 = Convert.ToInt32(number02);
            Console.WriteLine("Enter operator: ");
            string operation = Console.ReadLine();
            
                switch (operation)
                {
                    case "*":
                        Console.WriteLine($"The answer is {Number01 * Number02}.");
                        break;
                    case "/":
                        Console.WriteLine($"The answer is {Number01 / Number02}.");
                        break;
                    case "-":
                        Console.WriteLine($"The answer is {Number01 - Number02}.");
                        break;
                    case "+":
                        Console.WriteLine($"The answer is {Number01 + Number02}.");
                        break;
                    case "^":
                        Console.WriteLine($"The answer is {Math.Pow(Number01, Number02)}.");
                        break;
                    default:
                        Console.WriteLine("That is not valid.");
                        break;

                }
                Console.WriteLine("");
            



            Console.ReadKey();
        }
    }
}
