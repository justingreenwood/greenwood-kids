using System;
using System.Threading;

namespace forloopsandvariables8_21_2020
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Hello World!");
            int i;
            for (i = 5; i <= 100; i += 5)
            {
                Console.Write(i);
                Console.WriteLine("");
            }
            for (i= 1; i <= 1024; i *= 2)
            {
                if (i > 1024)
                    break;
                Console.Write(i);
                Console.WriteLine("");
            }
            Thread.Sleep(1000);
            Thread.Sleep(1000); 
            Thread.Sleep(1000); 
            Thread.Sleep(1000);
            Console.Clear();
            while (true)
            { Console.WriteLine("Algebra Expression Program");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("4(x + 12) - 24y / (3y - 4)");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
               num1:
                Console.WriteLine("enter the value for x");
                var a = Console.ReadLine();
                if (!double.TryParse(a, out double x))
                {
                    Console.WriteLine($"{a} is not a valid integer - DUMDUM!");
                    goto num1;
                }
                num2:
                Console.WriteLine("enter the value for y");
                var s = Console.ReadLine();
                if (!double.TryParse(s, out double y))
                {
                    Console.WriteLine($"{s} is not a valid integer - DUMDUM!");
                    goto num2;
                }
                Console.WriteLine($"the answer is {4*(x + 12) - 24*y / (3*y - 4)}");
            perry:
                Console.WriteLine("would you like to play again (y/n)");
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
