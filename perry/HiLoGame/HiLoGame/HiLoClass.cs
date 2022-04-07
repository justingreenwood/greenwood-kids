using System;
using System.Collections.Generic;
using System.Text;

namespace HiLoGame
{
    class HiLoClass
    {

        public const int Maximum = 10;
        private static Random random = new Random();
        private static int currentNumber = random.Next(1, Maximum);
        private static int pot = 10;
        public static int GetPot() { return pot; }

        public static void Guess(bool higher)
        {
            int number = random.Next(1, Maximum+1);
            if((higher&& number >= currentNumber) ||(higher == false&& number <= currentNumber))
            {
                Console.WriteLine("You chose wisely.");
                pot++;
            }
            else
            {
                Console.WriteLine("You chose poorly.");
                pot--;
            }
            currentNumber = number;
            Console.WriteLine($"The current number is {currentNumber}.");

        }
        public static void Hint()
        {

            int half = Maximum / 2;
            if (currentNumber >= half) 
            { 
                Console.WriteLine($"The number is at least {half}."); 
            }
            else
            {
                Console.WriteLine($"The number is at most {half}.");
            }

        }

    }
}
