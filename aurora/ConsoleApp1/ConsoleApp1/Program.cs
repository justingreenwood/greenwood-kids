using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm exhausted, so......");

            Console.WriteLine("8(x-2)");

            string Donuts;
            double Pastries;

            do
            {
                Console.WriteLine("Type in the first number for x. ");
                Donuts = Console.ReadLine();
            }

            while (!double.TryParse(Donuts, out Pastries));
            Console.WriteLine();

            string Cakes;
            double Pies;

            do
            {
                Console.WriteLine("Type in the last number for x. ");
                Cakes = Console.ReadLine();
            }

            while (!double.TryParse(Cakes, out Pies) || (Pies <= Pastries));
            Console.WriteLine();

            while (Pastries <= Pies)
            {
                Console.WriteLine(8 * (Pastries - 2));

                Pastries++;
            }
        }
    }
}
