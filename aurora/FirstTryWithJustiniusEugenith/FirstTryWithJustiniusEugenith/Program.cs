using System;
using System.Threading;

namespace FirstTryWithJustiniusEugenith
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("Hello, fellow idiot!");
            Console.WriteLine("Do you like cheese? ");
            var potato = Console.ReadLine();
            Console.WriteLine("You answered " + potato + "!");
            Console.ReadKey();
            Console.WriteLine(" ");
            Console.WriteLine("Thank you for clicking that key!");

            string x = @"\";
            int left = 10, top = 10;
            while (true)
            {
                Console.CursorLeft = left;
                Console.CursorTop = top;
                Console.Write(x);
                if (x == "|") x = "/";
                else if (x == "/") x = "-";
                else if (x == "-") x = @"\";
                else
                {
                    x = "|";
                    left++;
                    top++;
                    if (left >= Console.BufferWidth) left = 1;
                    
                }

                Thread.Sleep(10);
            }

             
           

        }
    }
}
