using System;

namespace AuroraProject4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to my amazingly bad programming accomplishment that I would rather throw into a dumpster.....");
        MyBeginning:
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[1] Add two numbers.");
            Console.WriteLine("[2] Subtract two numbers.");
            Console.WriteLine("[3] Multiply two numbers.");
            Console.WriteLine("[4] Divide two numbers.");
            Console.WriteLine("OR");
            Console.WriteLine("[Esc] Exit.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var pickles = Console.ReadKey();
            Console.WriteLine("  ");

      

            if (pickles.Key == ConsoleKey.D1)
            {
                UghMath.Addition();
                goto MyBeginning;
            }
            else if (pickles.Key == ConsoleKey.D2)
            {
                UghMath.Subtraction();

                goto MyBeginning;
            }
            else if (pickles.Key == ConsoleKey.D3)
            {
                UghMath.Multiplication();

                goto MyBeginning;
            }
            else if (pickles.Key == ConsoleKey.D4)
            {
                UghMath.Hell();

                goto MyBeginning;
            }
            else if (pickles.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("d Farewell, my dear true love!");
                goto TheEnd;
            }

            {
                void ExampleMethod(int required, int optionalInt = default(int),
                                          string description = "Optional Description")
                {
                    Console.WriteLine("{0}: {1} + {2} = {3}", description, required,
                                      optionalInt, required + optionalInt);
                }
            }

        TheEnd:;




    }
        
    }
}
