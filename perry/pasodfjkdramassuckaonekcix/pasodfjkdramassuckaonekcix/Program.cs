using System;

namespace pasodfjkdramassuckaonekcix
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            while (true)
            {
                
                var type = Console.ReadKey();

                if (type.Key == ConsoleKey.Enter)
                    Console.WriteLine();
                else if (type.Key == ConsoleKey.Escape)
                    break;
                else if (type.Key == ConsoleKey.Tab)
                    Console.Clear();
                
                

            }
            int a = 0;
            while (true)
            {
                Console.Write("~");
                a++;
                if(a == 3601)
                {
                    break;
                }
            }

        }
    }
}
