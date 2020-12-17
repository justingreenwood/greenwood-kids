using System;
using System.Threading;

namespace lovemaybe
{
    class Program
    {
        public const int NOTE_A = 220;
        public const int NOTE_B = 247;
        public const int NOTE_C = 262;
        public const int NOTE_D = 294;
        public const int NOTE_E = 330;
        public const int NOTE_F = 349;
        public const int NOTE_G = 392;

        static void Main(string[] args)
        {
            Console.Beep(NOTE_C, 1000);
            Console.Beep(NOTE_B, 1000);
            Console.Beep(NOTE_A, 2000);
            Console.Beep(NOTE_C, 1000);
            Console.Beep(NOTE_B, 1000);
            Console.Beep(NOTE_A, 2000);
            Console.Beep(NOTE_B, 1000);
            Console.Beep(NOTE_C, 1000); 
            Console.Beep(NOTE_B, 1000); 
            Console.Beep(NOTE_C, 1000);
            Console.Beep(NOTE_A, 2000);
            Console.Beep(NOTE_A, 2000);

            Console.WriteLine("Valetines day is a corparate holiday");
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to candy creations");
            int choclate = 1;

        TryAgain:
            Console.WriteLine("how many chocolates would you like");
            var theString = Console.ReadLine();
            if (!int.TryParse(theString, out int howmany1))
            {
                Console.WriteLine($"{theString} is not a valid integer - MORON!");
                goto TryAgain;
            }
            if ((howmany1 % 4) == 0)
            {
                Console.WriteLine($"{howmany1} is divisible by 4.");
            }
            switch (howmany1)
            {
                case 1:
                    Console.WriteLine($"{howmany1} is one.");
                    break;
                default:
                    Console.WriteLine($"{howmany1} is tasty.");
                    break;
            }
            Console.Beep(NOTE_F, 250);
            int taffy = 3;
        try2:
            Console.WriteLine("how much taffy would you like");
            var fluffy = Console.ReadLine();
            if (!int.TryParse(fluffy, out int howmany2))
            {
                Console.WriteLine($"a{fluffy} is not valid - try a number");
                goto try2;
            }
            Console.Beep(NOTE_G, 250);
            int heart = 5;
        puppy:
            Console.WriteLine("how many consternation hearts would you like");
            var hope = Console.ReadLine();
            if (!int.TryParse(hope, out int howmany3))
            {
                Console.WriteLine($"a{hope} isn't valid - try numbers");
                goto puppy;
            }
            Console.Beep(NOTE_C, 500);
            Console.Beep(NOTE_D, 500); 
            Console.Beep(NOTE_E, 1000); 
            Console.Beep(NOTE_C, 500); 
            Console.Beep(NOTE_D, 500);
            Console.Beep(NOTE_E, 1000);
            Console.Beep(NOTE_D, 500);
            Console.Beep(NOTE_C, 500);
            Console.Beep(NOTE_D, 500); 
            Console.Beep(NOTE_E, 500);
            Console.Beep(NOTE_C, 1000); 
            Console.Beep(NOTE_C, 1000);
            var cost = choclate * howmany1;
            var costs = taffy * howmany2;
            var costed = heart * howmany3;
            var prize = cost + costs + costed;
            Console.WriteLine(prize);
            Console.WriteLine("thank you for shopping at Candy Creations");
        }
    }
}
