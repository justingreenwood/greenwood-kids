using System;
using System.Collections.Generic;

namespace RogueLike
{
    class Dude
    {
        public int LastX = -1;
        public int LastY = -1;
        public int X;
        public int Y;
        public ConsoleColor Color;
    }

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            var d = new Dude
            {
                X = Console.WindowWidth / 2,
                Y = Console.WindowHeight / 2,
                Color = ConsoleColor.Blue
            };

            var options = new List<string>
            {
                "Quit", "Beep", "Colorize"
            };
            var selectedOption = 0;

            PaintBackground();
            PaintMenu(options, selectedOption);

            var keepGoing = true;
            ConsoleKeyInfo key;
            do
            {
                Paint(d);
                key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        keepGoing = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        d.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        d.X++;
                        break;
                    case ConsoleKey.UpArrow:
                        d.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        d.Y++;
                        break;
                    case ConsoleKey.Tab:
                        selectedOption++;
                        if (selectedOption >= options.Count)
                        {
                            selectedOption = 0;
                        }
                        PaintMenu(options, selectedOption);
                        break;
                    case ConsoleKey.Enter:
                        if (options[selectedOption] == "Quit")
                        {
                            keepGoing = false;
                        }
                        else if (options[selectedOption] == "Beep")
                        {
                            Console.Beep();
                        }
                        else if (options[selectedOption] == "Colorize")
                        {
                            d.Color = (ConsoleColor)random.Next(16);
                        }
                        break;
                }
            } while (keepGoing);

        }

        static void PaintMenu(List<string> items, int selectedIndex)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (var i = 0; i < items.Count; i++)
            {

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.Write(items[i]);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
            }
        }

        static void PaintBackground()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            var rows = Console.WindowHeight;
            var columns = Console.WindowWidth;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int x = 1; x < columns - 1; x++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = 1;
                Console.Write("═");
                Console.CursorLeft = x;
                Console.CursorTop = rows - 1;
                Console.Write("═");
            }
            for (int y = 1; y < rows - 1; y++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = y;
                Console.Write("║");
                Console.CursorLeft = columns - 1;
                Console.CursorTop = y;
                Console.Write("║");
            }
            /*
╔═════╗
║65001║
╚═════╝*/
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.Write("╔");
            Console.CursorLeft = 0;
            Console.CursorTop = rows - 1;
            Console.Write("╚");
            Console.CursorLeft = columns - 1;
            Console.CursorTop = 1;
            Console.Write("╗");
            Console.CursorLeft = columns - 1;
            Console.CursorTop = rows - 1;
            Console.Write("╝");
        }

        static void Paint(Dude d)
        {
            if (d.LastX >= 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.CursorLeft = d.LastX;
                Console.CursorTop = d.LastY;
                Console.Write(" ");
            }

            Console.ForegroundColor = d.Color;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = d.X;
            Console.CursorTop = d.Y;
            Console.Write("?");

            d.LastX = d.X;
            d.LastY = d.Y;
        }
    }
}
