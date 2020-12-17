using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace simpleexpresion8_19_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Algebra Expresion Program");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("4(x + 12) - 24");
                num:
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.Write("enter a value for x");
               var y = Console.ReadLine();
                if (!double.TryParse(y, out double x))
                {
                    Console.WriteLine($"{y} is not a valid integer - DUMDUM!");
                    goto num;
                }
                Console.WriteLine($"Your answer is { 4 *(x + 12) - 24}");
                perry:
                Console.Write("would you you like to play again y/n");
                var ans = Console.ReadKey();
                if (ans.Key == ConsoleKey.N)
                   break;
                else if (ans.Key == ConsoleKey.Y)
                    Console.WriteLine("OKAY");
                else
                {
                    Console.WriteLine("Your idiotic");
                    goto perry;
                }
            }
         



        }
    }
}
