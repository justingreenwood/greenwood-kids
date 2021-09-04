using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public static class GameLoop
    {
        public static Random _rand = new Random();
        public static void Run()
        {
            int fps = 1;
            int frms = 1000 / fps;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("[X] - Press ESC to stop");
            ConsoleKey? lastKeyPressed = null;
            Console.CursorVisible = false;
            char c = 'X';
            var sw = new Stopwatch();
            do
            {
                sw.Start();
                while (!Console.KeyAvailable)
                {
                    if (lastKeyPressed.HasValue) 
                    {
                        char tmp = (char)lastKeyPressed.Value;
                        if (c != tmp && char.IsLetterOrDigit(tmp)) c = tmp;
                        else if (lastKeyPressed == ConsoleKey.UpArrow && fps < 1000) fps += 1;
                        else if (lastKeyPressed == ConsoleKey.DownArrow && fps > 1) fps -= 1;

                        frms = 1000 / fps;
                        lastKeyPressed = null;

                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine($"FPS={fps} FRMS={frms}                                ");
                    }
                    if (sw.ElapsedMilliseconds >= frms)
                    {
                        // Do something
                        Console.ForegroundColor = (ConsoleColor)(_rand.Next(16));
                        Console.SetCursorPosition(1, 0);
                        Console.Write(c);
                        sw.Restart();
                    }
                }
                sw.Stop();
            } while ((lastKeyPressed = Console.ReadKey(true).Key) != ConsoleKey.Escape);
            Console.CursorVisible = true;
        }
    }
}
