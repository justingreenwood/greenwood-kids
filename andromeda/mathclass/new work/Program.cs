using System;

namespace new_work
{
    class Dude
    {
        public int LastX;
        public int LastY;
        public int X;
        public int Y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dude { X = Console.WindowWidth / 2, Y = Console.WindowHeight / 2 };

            PaintBackground();

            ConsoleKeyInfo key;
            do
            {
                Paint(d);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
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
                }
            } while (key.Key != ConsoleKey.Escape);

        }

        static void PaintBackground()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            var rows = Console.WindowHeight;
            var columns = Console.WindowWidth;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            for (int x = 0; x < columns; x++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = 0;
                Console.Write('#');
                Console.CursorTop = rows -1;
                Console.Write('#');
            }
            for (int y = 1; y < rows ; y++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = y;
                Console.Write('#');
                Console.CursorLeft = columns - 1;
                Console.Write('#');
            }
        }

        static void Paint(Dude d)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = d.LastX;
            Console.CursorTop = d.LastY;
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.CursorLeft = d.X;
            Console.CursorTop = d.Y;
            Console.Write("*");

            d.LastX = d.X;
            d.LastY = d.Y;
        }

    }
}
