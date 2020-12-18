using System;

namespace PotatoLove
{
    class Program
    {
        static void Main(string[] args)
        {
            int PotatoLove;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            for (PotatoLove = 8; PotatoLove <= 800; PotatoLove += 8)
            {
                Console.WriteLine(PotatoLove);
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();

            for (PotatoLove = 1; PotatoLove <= 1500; PotatoLove *= 2)
            {
                if (PotatoLove > 1500)
                    break;
                else
                    Console.WriteLine(PotatoLove);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();

            for (PotatoLove = 5; PotatoLove <= 100; PotatoLove += 5) 
            {
                Console.WriteLine(PotatoLove);
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" This is how you multiply to a ridiculous amount! I will continue? I'm not sure...");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();

            for (PotatoLove = 2; PotatoLove <= 1000; PotatoLove += 2)
            {
                Console.WriteLine(PotatoLove);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            for (PotatoLove = 3; PotatoLove <= 120; PotatoLove += 3)
            {
                Console.WriteLine(PotatoLove);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();

            for (PotatoLove = 7; PotatoLove <= 140; PotatoLove += 7)
            {
                Console.WriteLine(PotatoLove);

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();

            for (PotatoLove = 10; PotatoLove <= 10000; PotatoLove += 10)
            {
                Console.WriteLine(PotatoLove);
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }
    }
}
