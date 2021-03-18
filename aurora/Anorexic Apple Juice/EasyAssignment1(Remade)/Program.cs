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

            if (FirstNumber2>=0||SecondNumber2>=0)
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
            var taco=Console.ReadLine();
            Console.WriteLine("You said " + taco + "!");

            //Aurora has more work to do.
            string message = "Hello World";
            message = "Purple Monkey Machine Gun in a Dishwasher";
            Console.WriteLine($"I want a {message}!");


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
            
             
         

        }
    }

}
