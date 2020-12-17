using System;
using System.Numerics;

namespace colors8_10_2020
{
  class Program
  {
     static void Main(string[] args)
     {
        again:
        Console.WriteLine("what color");
        string color = Console.ReadLine();
        color = color.ToLower();
            if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Limes are green.");
            }
            else if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lemons are yellow.");
            }
            else if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cheries are red.");
            }
            else if (color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Blueberrys are blue");
            }
            else if (color == "dark blue")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Blackberrys are dark blue.");
            }
            else if (color == "black")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Perry's favorite color is black.");
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else if (color == "magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Magenta is my favorite shade of purple.");
            }
            else if (color == "dark red")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Dark red is the color of fruit punch.");
            }
            else
            {
                Console.WriteLine("Please check if it is a real color.");
            }
        Q:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to play again(n/y)");
            string ans = Console.ReadLine();
            ans = ans.ToLower();
            if (ans == "y")
            {
                Console.WriteLine("yeah");
                goto again;
            }
            else if (ans == "n")
            {
                Console.WriteLine("?");
            }
            else
            {
                goto Q;
            }
     }

  }
}
