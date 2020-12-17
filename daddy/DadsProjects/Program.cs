using DadsProjects.Monsters;
using System;
using System.Globalization;
using System.Threading;

namespace DadsProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "JUSTIN Greenwood";
            char myLetter = 'j';
            int numberOfChildren = 5;
            decimal moneyInWallet = 2523423423423475.45m;
            var oneThird = 1.0 / (float)3;
            bool isMale = true;

            if (name.Equals("Justin Greenwood", StringComparison.InvariantCultureIgnoreCase))
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
                Console.WriteLine($"You are dumb! {moneyInWallet.ToString("C", CultureInfo.CurrentCulture)}");
            }

            // OR IS ||
            // AND IS &&
            if ((isMale || name == "aurora") && oneThird > 0)
            {
                Console.WriteLine($"Perry Peach!");
            }

            while (true)
            {
                var keypressed = Console.ReadKey();

                switch (keypressed.Key)
                {
                    case ConsoleKey.Enter:
                        if (keypressed.Modifiers == ConsoleModifiers.Shift)
                        {
                            Console.WriteLine("You pressed SHIFT ENTER!");
                        }
                        else
                        {
                            Console.WriteLine("You pressed ENTER!");
                        }
                        break;
                    case ConsoleKey.Tab:
                        Console.WriteLine("You pressed TAB!");
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.B:
                    case ConsoleKey.C:
                        Console.WriteLine("You're a big kid now!");
                        break;
                    default:
                        Console.WriteLine("BAD OPTION!");
                        break;
                }

                //if (keypressed.Key == ConsoleKey.Enter && keypressed.Modifiers == ConsoleModifiers.Shift)
                //{
                //    Console.WriteLine("You pressed shift ENTER!");
                //}
                //else if (keypressed.KeyChar == myLetter)
                //{
                //    Console.WriteLine("My favorite!");
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine($"[[{keypressed.KeyChar}]]");
                //}
            }



            string myName = "Justin";
            //Console.ForegroundColor = Monster.GetRandomColor();

            Monster.WriteCoolCrap("What is your name? ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            myName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            double y = 0.0;
            double x = 20.0 / y;
            if (double.IsInfinity(x))
            {
                Console.WriteLine("DIVIDE BY 0!!!");
            }
            else
            {
                Console.WriteLine("Hello from Dads Project!" + x + " " + myName);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
