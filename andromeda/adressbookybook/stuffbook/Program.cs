using System;

namespace stuffbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleKeyInfo chose;
            bool isplaying = true;
            while (isplaying)
            {

                Console.WriteLine("(Q)uit,(S)ave,(L)ist,(A)dd,(R)emove");
                chose = Console.ReadKey();

                Console.WriteLine();
                if (chose.Key == ConsoleKey.Q)
                {
                    isplaying = false;
                }
                else if (chose.Key == ConsoleKey.S)
                {
                    Console.WriteLine("......................");
                }
                else if (chose.Key == ConsoleKey.L)
                {
                    Console.WriteLine("123");
                }
                else if (chose.Key == ConsoleKey.A)
                {
                    Console.WriteLine("cool");
                }
                else if (chose.Key == ConsoleKey.R)
                {
                    Console.WriteLine("are you sure");
                }
                else
                {
                    Console.WriteLine("you dumb; you really dumb");
                }
            }
        }
    }
}
