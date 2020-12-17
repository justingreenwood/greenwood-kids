using System;

namespace ColorsPerry
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type in a color. ");
                var color = Console.ReadLine();
                color = color.ToLower();
                if (color == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Most tomatoes are red.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Blue is blue.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Bananas are yellow.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "magenta")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Magenta is magenta.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Grass is green.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "cyan")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The sky is cyan.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "gray")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Old peoples hair are gray.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark blue")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Blue berries are dark blue.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark yellow")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Dark yellow is dark yellow.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark magenta")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Some grapes are dark magenta.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark cyan")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("The evening sky is dark cyan.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark gray")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Your face is dark gray.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "dark green")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Pine needles are dark green.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (color == "white")
                {
                    Console.WriteLine("Normal paper is white.");
                }
                else if (color == "black")
                {
                    Console.WriteLine("Black does not count as a color.");
                }
                else
                {
                    Console.WriteLine($"{color} is not a color.");
                }
                begin:
                Console.WriteLine("Do you want to play again.(y or n)");
                var answer = Console.ReadKey();
                if (answer.Key == ConsoleKey.N)
                {
                    break;
                }
                else if(answer.Key == ConsoleKey.F5)
                {
                    Console.WriteLine("F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5F5");
                    goto begin;
                }
                else if (!(answer.Key == ConsoleKey.N ||answer.Key == ConsoleKey.Y || answer.Key == ConsoleKey.F5))
                {
                    Console.WriteLine("That is not an answer.");
                    goto begin;
                }
                
            }


        }
    }
}
