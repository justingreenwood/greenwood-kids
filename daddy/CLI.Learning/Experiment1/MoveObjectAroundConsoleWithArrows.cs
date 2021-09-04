using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public static class MoveObjectAroundConsoleWithArrows
    {
        public static Random _rand = new Random();
        public static void Run()
        {
            //var ratio = (float)Console.WindowWidth / (float)Console.BufferWidth;
            //Console.WriteLine($"1 - [{Console.BufferWidth}, {Console.BufferHeight}]");
            //Console.WriteLine($"2 - [{Console.WindowWidth}, {Console.WindowHeight}]");
            //Console.WriteLine($" {(Console.WindowWidth / Console.BufferWidth)} {(ratio * Console.WindowHeight)}");


            //Console.ReadKey();
            //Console.WriteLine($" [{Console.BufferWidth}, {Console.BufferHeight}]");


            ConsoleKeyInfo k;
            Rectangle r = new Rectangle(10, 10, 6, 2);

            Console.CursorVisible = false;

            DrawBackground();
            DrawThingy(r);

            while ((k = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                Rectangle? newRect = null;
                switch (k.Key)
                {
                    case ConsoleKey.RightArrow:
                        newRect = new Rectangle(r.X + 1, r.Y, r.W, r.H);
                        break;
                    case ConsoleKey.LeftArrow:
                        newRect = new Rectangle(r.X - 1, r.Y, r.W, r.H);
                        break;
                    case ConsoleKey.UpArrow:
                        newRect = new Rectangle(r.X, r.Y - 1, r.W, r.H);
                        break;
                    case ConsoleKey.DownArrow:
                        newRect = new Rectangle(r.X, r.Y + 1, r.W, r.H);
                        break;
                }
                if (newRect.HasValue && IsValidLocation(newRect.Value))
                {
                    DrawPartialBackground(newRect.Value, r);
                    r = newRect.Value;
                }
                else
                {
                    DrawPartialBackground(r);
                }

                DrawThingy(r);
            }

            Console.CursorVisible = true;
        }

        private static Size SavedConsoleSize;

        public static bool HasConsoleSizeChanged => SavedConsoleSize.W != Console.WindowWidth || SavedConsoleSize.H != Console.WindowHeight;
        public static void SetConsoleSize() => SavedConsoleSize = new Size(Console.WindowWidth, Console.WindowHeight);
        public static bool IsValidLocation(Rectangle rect)
        {
            return (rect.X > 0) && (rect.Y > 0) && (rect.X + rect.W < Console.WindowWidth) && (rect.Y + rect.H < Console.WindowHeight);
        }
        private static void DrawPartialBackground(params Rectangle[] rects)
        {
            int? x1 = null, y1 = null, x2 = null, y2 = null;
            foreach (var rect in rects)
            {
                x1 = Math.Min(rect.X, x1 ?? Console.WindowWidth);
                y1 = Math.Min(rect.Y, y1 ?? Console.WindowHeight);
                x2 = Math.Max(rect.X + rect.W, x2 ?? 0);
                y2 = Math.Max(rect.Y + rect.H, y2 ?? 0);
            }
            DrawBackground(x1, y1, x2, y2);
        }

        public static ConsoleColor _bgcolor;
        public static ConsoleColor _fgcolor;
        public static void SaveColors()
        {
            _bgcolor = Console.BackgroundColor;
            _fgcolor = Console.ForegroundColor;
        }
        public static void RestoreColors()
        {
            Console.BackgroundColor = _bgcolor;
            Console.ForegroundColor = _fgcolor;
        }

        public static void DrawThingy(Rectangle rect)
        {
            SaveColors();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (var y = rect.Y; y < (rect.Y + rect.H); y++)
            {
                for (var x = rect.X; x < (rect.X + rect.W); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("+");
                }
            }
            RestoreColors();
        }

        private static void DrawBackground(int? left = null, int? top = null, int? right = null, int? bottom = null)
        {
            var draw = false;
            if (HasConsoleSizeChanged)
            {
                draw = true;
                left = 0;
                top = 0;
                right = Console.WindowWidth;
                bottom = Console.WindowHeight;
                SetConsoleSize();
            }
            else if (left.HasValue || top.HasValue || right.HasValue || bottom.HasValue)
            {
                draw = true;
                left ??= 0;
                top ??= 0;
                right ??= Console.WindowWidth;
                bottom ??= Console.WindowHeight;
            }

            if (draw)
            {
                Console.ForegroundColor = (ConsoleColor)(_rand.Next(16));

                for (var y = top.Value; y < bottom; y++)
                {
                    for (var x = left.Value; x < right; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        if (x == 0 || x == Console.WindowWidth - 1 || y == 0 || y == Console.WindowHeight - 1)
                        {
                            Console.Write("#");
                        }
                        else
                        {

                            Console.Write("~");
                        }
                    }
                }
            }
        }
    }
}
