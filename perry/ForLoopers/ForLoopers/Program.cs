using System;
using System.Globalization;

namespace ForLoopers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for (i = 5; i <= 100; i += 5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            for (i = 1; i <= 1500; i *= 2)
            {
                if (i > 1500)
                    break;
                else
                    Console.WriteLine(i);
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("3(j-3) + 5i / 2(i + 7)");
            string J;
            double j;
            do
            {
                Console.WriteLine("j = ?");
                J = Console.ReadLine();
            } while (!double.TryParse(J, out j));

            string I;
            double Is;
            do
            {
                Console.WriteLine("i = ?");
                I = Console.ReadLine();
            } while (!double.TryParse(I, out Is));

            Console.WriteLine($"The answer is {3 * (j - 3) + 5 * Is / 2 * (Is + 7)}");

        }
    }
}
