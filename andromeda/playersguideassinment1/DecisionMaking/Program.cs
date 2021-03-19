using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int score;
            Console.WriteLine("Enter your score:");
            string scoreastext = Console.ReadLine();
            score = Convert.ToInt32(scoreastext);
            if (score == 100)
            {
                Console.WriteLine("Perfect score! You win!");
                Console.WriteLine("That's awsome!");
            }
            else if (score == 99)
            {
                Console.WriteLine("Missed it by THAT much.");
            }
            else if (score == 0)
            {
                Console.WriteLine("You must have been TRYING to get that score.");
            }
            else
            {
                Console.WriteLine("Ah, come on! That's just boring. Next time get a more interesting score.");
            }
            Console.ReadKey();
            if (score != 100)
            {
                //not used
            }
            if (score > 90)
            {
                Console.WriteLine("You got an 'A'!");
            }
            if (score < 60)
            {
                Console.WriteLine("You got an 'F'. Sorry.");
            }
            if (score >= 90)
            {
                Console.WriteLine("You got an 'A'!");
            }
            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            if (score >= 90)
            {
                Console.WriteLine("You got an A!");
            }
            else if (score >= 80)
            {
                Console.WriteLine("You got an B!");
            }
            else if (score >= 70)
            {
                Console.WriteLine("You got an C!");
            }
            else if (score >= 60)
            {
                Console.WriteLine("You got an D!");
            }
            else
            {
                Console.WriteLine("You got an F!");
            }
            Console.ReadKey();
            //<><><><<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>
           int Score = 45;
            int pointsNeededToPass = 100;
            bool levelComplete = (Score >= pointsNeededToPass);
            if (levelComplete)
            {
                Console.WriteLine("You've beaten the level!");
            }
            if (!levelComplete)
            {
                Console.WriteLine("You haven't won yet. Better keep trying...");
            }
            //@#$#@#$#@#@$#@#@#@#$@#$@#@$#@#$@#@#@$#@#$@#$@$$@#@#@#$@
            int a;
            int b;
            Console.WriteLine("Enter your first number:");
            string aString = Console.ReadLine();
            a = Convert.ToInt32(aString);
            b = 2;
            int remainder;
            remainder = a % b;
            if (remainder == 1)
            {
                Console.WriteLine("number is odd");
            }
            else
            {
                Console.WriteLine("number is even");
            }
            int shields = 50;
            int armor = 20;
            if (shields <= 0 && armor <= 0)
                Console.WriteLine("You're dead.");
            if (shields > 0 || armor > 0)
                Console.WriteLine("You're still alive! Keep going!");
            if (shields <= 0)
            {
                if (armor <= 0)
                {
                    Console.WriteLine("Your shields and armor are both zero! You're dead.");
                }
                else
                {
                    Console.WriteLine("Sheilds are gone, but armor is keeping you alive!");
                }
            }
            else
            {
                Console.WriteLine("You still have sheilds left. The world is safe.");
            }
            int num1;
            Console.WriteLine("Enter num:");
            string text1 = Console.ReadLine();
            num1 = Convert.ToInt32(text1);
            int num2;
            Console.WriteLine("Enter another num:");
            string text2 = Console.ReadLine();
            num2 = Convert.ToInt32(text2);
            if ((num1 <= 0 && num2 >= 0) || (num2 <= 0 && num1 >= 0))
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Positive");
            }
            Console.WriteLine((score > 70) ? "You passed!" : "You failed.");
            Console.ReadKey();
        }
    }
}
