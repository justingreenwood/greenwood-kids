using System;

namespace PerrysStuffidyStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            int top = 3, left = 3;

            var windowwidth = Console.WindowWidth;
            var windowheight = Console.WindowHeight;



            for (int j = 1; j <= (windowheight - 1); j++)
            {
                Console.WriteLine("|");
            }

            for (int j = 1; j <= (windowwidth - 1); j++)
            {
                Console.Write("-");
            }
            Console.CursorLeft = 1;
            Console.CursorTop = 0;
            for (int j = 1; j <= (windowwidth - 2); j++)
            {
                Console.Write("-");
            }
            for (int j = 1; j <= (windowheight - 1); j++)
            {
                Console.CursorLeft = windowwidth-1;
                Console.WriteLine("|");
            }

            //----------------------------------------------------------------------

            Console.CursorLeft = 13;
            Console.CursorTop = 7;

            for (int j = 1; j <= 7; j++)
            {
                Console.CursorLeft = 13;
                Console.WriteLine("|");
            }
            Console.CursorLeft = 13;
            for (int j = 1; j <= 23; j++)
            {  
                Console.Write("-");
            }
            Console.CursorLeft = 13;
            Console.CursorTop = 7;
            for (int j = 1; j <= 23; j++)
            {
                Console.Write("-");
            }
            Console.CursorTop = 8;
            for (int j = 1; j <= 6; j++)
            {
                Console.CursorLeft = 35;
                Console.WriteLine("|");
            }


























            while (true)
            {
                var player = Console.ReadKey(true);

                Console.Write(' ');

                if (player.Key == ConsoleKey.UpArrow)
                {
                    if (top >= 2)
                    {
                        top--;
                    }
                }
                else if (player.Key == ConsoleKey.DownArrow)
                {
                    top++;
                }
                else if (player.Key == ConsoleKey.LeftArrow)
                {
                    if (left >= 2)
                    {
                        left--;
                    }
                }
                else if (player.Key == ConsoleKey.RightArrow)
                {
                    left++;
                }

                if (windowwidth != Console.WindowWidth || windowheight != Console.WindowHeight)
                {
                    Console.SetWindowSize(windowwidth, windowheight);
                }




                if (left >= Console.WindowWidth - 2)
                {
                    left = Console.WindowWidth - 2;
                }
                if (top >= Console.WindowHeight - 2)
                {
                    top = Console.WindowHeight - 2;
                }


                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.Write('@');
                Console.CursorLeft = left;
                Console.CursorTop = top;
            }


            
        }
    }
}
