using System;
using System.Net;

namespace SpencersProgrammingIsAwesome
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello World!");
                rats:
                Console.WriteLine("When did you come back to Homework?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you do? (L)ie, (T)ell the truth, or (I)gnore");
                
                Console.ForegroundColor = ConsoleColor.White;
                var LTI = Console.ReadKey();
                Console.WriteLine();
                if (LTI.Key == ConsoleKey.L)
                {
                    Console.WriteLine("You're lying. You were fighting against The Town of Greenleaf at that time.");
                    goto rats;
                }
                else if (LTI.Key == ConsoleKey.I)
                {
                    Console.WriteLine("How dare you ignore me.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("He pulls out a gun and shoots you.");
                    Console.WriteLine("THE END");
                    break;
                }
                else if (LTI.Key == ConsoleKey.T)
                {
                    Console.WriteLine("Why didn't you tell me?");
                    Console.WriteLine("And because you didn't tell me. You will be torchered hehehehe");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You were knocked out.");
                }
                else
                    goto rats;
                Console.WriteLine("You woke up in a cell and all you see is a computer next to a metal door, a potted plant, and a little slot in the wall.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you do? (The verbs are: look, open, close, enter, use/use with, push, pull, and take.)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();








                break;
            }
        }
    }
}
