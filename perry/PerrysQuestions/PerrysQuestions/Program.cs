using System;
using System.Threading;

namespace PerrysQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to bunnies and kittens.");
            Console.WriteLine("We will show you pictures of bunnies and kittens, and you choose which you prefer.");
            Thread.Sleep(7000);
            Console.WriteLine("Just kidding.");
            Beginning:
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            fart:
            Console.Write("What is your gender? (m/f) ");
            var gender = Console.ReadKey();
            string newgender;
            if (!(gender.Key == ConsoleKey.M || gender.Key == ConsoleKey.F || gender.Key == ConsoleKey.NumPad2))
            {
                Console.WriteLine(" ");
                Console.WriteLine("You are stupid.");
                goto fart; 
            }
            else if (gender.Key == ConsoleKey.M)
            {
                 Console.WriteLine(" ");
                 newgender = "Mr.";
            }
            else if (gender.Key == ConsoleKey.F)
            {
                Console.WriteLine(" ");
                newgender = "Mrs.";
            }
            else
            {
                Console.WriteLine(" ");
                newgender = "Bunny";
            }

            string age;
            int newage;
            do
            {
                Console.Write($"What is your age? ");
                age = Console.ReadLine();
            } while (!int.TryParse(age, out newage));


            string height;
            double newheight;
            do
            {
                Console.Write($"What is your height? ");
                height = Console.ReadLine();
            } while (!double.TryParse(height, out newheight));

            if (newheight > 5.6)
            {
                height = "tall";
            }
            else if (newheight < 5.3)
            {
                height = "short";
            }
            else 
            {
                height = "normal heighted";
            }

            Console.WriteLine($"You are {newgender} {name}, and you are a {height} {newage} year old.");

            Idiot:
            Console.Write("Do you want to play again? (y/n) ");
            var yousuck = Console.ReadKey();
            if (yousuck.Key == ConsoleKey.Y)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Ok.");
                goto Beginning;
            }
            else if (yousuck.Key == ConsoleKey.N)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Ok, bye {newgender} {name}.");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine($"You are an idiot {name}.");
                goto Idiot;
            }
        }
    }
}
