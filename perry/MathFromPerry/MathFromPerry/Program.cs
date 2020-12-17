using System;
using System.Threading;

namespace MathFromPerry
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to The Simple Calculator.");
            beginning:
            Console.WriteLine("[F1] Add two numbers.");
            Console.WriteLine("[F2] Subtract two numbers.");
            Console.WriteLine("[F3] Multiply two numbers.");
            Console.WriteLine("[F4] Divide two numbers.");
            Console.WriteLine("[F5] Square a number.");
            Console.WriteLine("[F6] Square root a number.");
            Console.WriteLine(" ");
            Console.WriteLine("[Esc] Exit.");
            var choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.F1)
            {
                Console.WriteLine(" ");
                Addition.apple();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.F2)
            {
                Console.WriteLine(" ");
                Addition.SugarSnapPeas();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.F3)
            {
                Console.WriteLine(" ");
                Addition.mango();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.F4)
            {
                Console.WriteLine(" ");
                Addition.durian();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.F5)
            {
                Console.WriteLine(" ");
                Addition.tomato();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.F6)
            {
                Console.WriteLine(" ");
                Addition.tomatoes();
                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if(choice.Key == ConsoleKey.LeftWindows)
            {
                var newwindow = Console.ReadKey();
                Console.WriteLine(" ");
                if (newwindow.Key == ConsoleKey.RightWindows)
                {
                    Console.WriteLine("I am the vindow viper. I am here to vipe your vindows.");
                    Thread.Sleep(2000);
                    int arrow = 0;
                    while (true)
                    {
                        Console.WriteLine("Windows");
                        arrow ++;
                        Thread.Sleep(500);
                        if (arrow == 40)
                        {
                            break;
                        }
                    }

                }

                Console.ReadKey();
                Console.Clear();
                goto beginning;
            }
            else if (choice.Key == ConsoleKey.Escape)
            {
                Console.WriteLine(" ");
                Console.WriteLine("BBye");  
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("You are an idiot.");
                Thread.Sleep(1000);
                Console.Clear();
                goto beginning;
            }
        }
    }
}
