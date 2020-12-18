using System;

namespace DUUUUUUUUUUUUUUUUUUUUUUUUUUUUDE_
{
    class Program
    {
        static void Main(string[] args)
        {
        WeirdHumanity:
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("7(potato + 53) - 65");
            string A;
            double a;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Type in a value for potato:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                A = Console.ReadLine();
            } while (!double.TryParse(A, out a));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The answer is {7 * (a + 53) - 65}");
        Blech:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Do you want to play again? (Y/N)");
            Console.ForegroundColor = ConsoleColor.Red;
            var key = Console.ReadKey();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (key.Key == ConsoleKey.Y)
                goto WeirdHumanity;
            else if (key.Key == ConsoleKey.N)
                Console.WriteLine("Farewell, my good sir.");
            else
            {
                Console.WriteLine("You are so darn dumb! I bet you don't know the difference between a ferret and a weasel!");
                goto Blech;
            }
        }
    }
}

