using System;

namespace EasyAssignment1_Remade_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Printing Hello World is one of the first steps in our programming adventure.
            Console.WriteLine("Hello, world!");
            //Reading the line that they type.
            Console.ReadLine();
            //naming an integer
            int score;
            //state the score
            score = 8;
            //print score
            Console.WriteLine(score);
            //naming another int and stating what it equals
            int PerryCurrentAge = 13;
            //printing Perry's age
            Console.WriteLine("Perry is currently " + PerryCurrentAge + " years old.");

            int addition = 3 + 4;
            int result = 7;

            float radius = 4;
            float pi = 3.1415926536f;
            float area = pi * radius * radius;
            Console.WriteLine("The area of a circle is " + area + ".");

            Console.WriteLine(" I'm sorry, Dave, but I'm afraid that I can't do that.");

            int FirstNumber2;
            int SecondNumber2;
            double a = 1.0 + 1 + 1.0f;
            int x = (int)(7 + 3.0 / 4 * 2);
            Console.WriteLine((1 + 1) / 2 * 3);

            Console.WriteLine(" Give me a number.");
            var FirstNumber = Console.ReadLine();
            Console.WriteLine("Give me another number.");
            var SecondNumber = Console.ReadLine();
            FirstNumber2 = Convert.ToInt32(FirstNumber);
            SecondNumber2 = Convert.ToInt32(SecondNumber);

            if (FirstNumber2 >= 0 || SecondNumber2 >= 0)
            {
                Console.WriteLine(" This is positive!");
            }
            else if (FirstNumber2 <= 0 || SecondNumber2 <= 0)
            {
                Console.WriteLine(" This is positive!");
            }
            else if (FirstNumber2 == 0 || SecondNumber2 == 0)
            {
                Console.WriteLine("That is zero, which is neither negative nor positive.");
            }
            else
            {
                Console.WriteLine("That is negative!");
            }

            Console.WriteLine("Choose a number from one to ten. Any number!");
            var taco = Console.ReadLine();
            Console.WriteLine("You said " + taco + "!");

            //Aurora has more work to do.
            string message = "Hello World";
            message = "Purple Monkey Machine Gun in a Dishwasher";
            Console.WriteLine($"I want a {message}!");

            int menuChoice = 3;

            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine(" You suck.");
                    break;
                case 2:
                    Console.WriteLine(" You suck.");
                    break;
                case 3:
                    Console.WriteLine(" You suck.");
                    break;
                case 4:
                    Console.WriteLine(" You suck.");
                    break;
                default:
                    Console.WriteLine(" You suck.");
                    break;
            }

            //Console.WriteLine("   *    ");
            //Console.WriteLine("  ***   ");
            //Console.WriteLine(" ***** ");
            //Console.WriteLine("*******");

            for (int row = 0; row < 5; row++)
            {
                for (int column = 5; column > row; column--)
                    Console.Write(" ");
                for (int column = 0; column <= row * 2; column++)
                    Console.Write("*");
                Console.WriteLine();

            }

            for (x = 1; x <= 100; x++)
            {
                int j = x % 3;
                int i = x % 5;
                if (j == 0 && i == 0)
                {
                    Console.WriteLine("FUZZBUTT");
                }
                else if (j == 0)
                {
                    Console.WriteLine("FUZZ");
                }
                else if (i == 0)
                {
                    Console.WriteLine("BUTT");
                }
                else
                {
                    Console.WriteLine(x);
                }
            }

            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

            int total = 0;

            for (int index = 0; index < array.Length; index++)
                total += array[index];

            float average = (float)total / array.Length;

            var tacos = array;

            foreach (int tiny in tacos)
            {
                int[] scores = new[] { 100, 32, -34, -24, 23, 22 };

                //int TotalThingsInForEach = Array.Length();
            }



            string palindrome = "Taco Cat";
            var MeaningofLife = 42;

            if (palindrome=="Taco Cat")
            {
                Console.WriteLine("You are so weird.");
            }
            else
            {
                Console.WriteLine("This isn't possible!");
            }
        }

        static void MethodThatUsesRecursions()
        {
            MethodThatUsesRecursions();
        }

        class Book
        {
            private string title;
            private string author;
            private int pages;
            private int WordCount;

            public Book(string title, string author)
            {
                this.title = title;
                this.author = author;
            }
            
           enum MonthsOfYear { January=1, February=2, March=3, April=4, May=5, June=6, July=7, August=8, September=9, October=10, November=11, December=12};
            string minimonths = "The month is this month.";

        }
    }

}
