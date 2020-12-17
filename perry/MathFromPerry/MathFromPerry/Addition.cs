using System;
using System.Collections.Generic;
using System.Text;

namespace MathFromPerry
{
    public class Addition
    {
        //private static Random mathstuff = new Random();
        public static void apple()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type the first number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));
            string numbers;
            double anumbers;
            do
            {
                Console.Write("Type the second number. ");
                numbers = Console.ReadLine();
            } while (!double.TryParse(numbers, out anumbers));

            Console.WriteLine($"{anumber} + {anumbers} = {anumbers + anumber}");
        }

        public static void SugarSnapPeas()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type the first number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));
            string numbers;
            double anumbers;
            do
            {
                Console.Write("Type the second number. ");
                numbers = Console.ReadLine();
            } while (!double.TryParse(numbers, out anumbers));

            Console.WriteLine($"{anumber} - {anumbers} = {anumber - anumbers}");
        }

        public static void mango()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type the first number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));
            string numbers;
            double anumbers;
            do
            {
                Console.Write("Type the second number. ");
                numbers = Console.ReadLine();
            } while (!double.TryParse(numbers, out anumbers));

            Console.WriteLine($"{anumber} X {anumbers} = {anumbers * anumber}");
        }

        public static void durian()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type the first number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));
            string numbers;
            double anumbers;
            do
            {
                Console.Write("Type the second number. ");
                numbers = Console.ReadLine();
            } while (!double.TryParse(numbers, out anumbers));

            Console.WriteLine($"{anumber} / {anumbers} = {anumber / anumbers}");
        }

        public static void tomatoes()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type a number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));

            Console.WriteLine($"The square root of {anumber} is {Math.Sqrt(anumber)}.");
        }

        public static void tomato()
        {
            string number;
            double anumber;
            do
            {
                Console.Write("Type a number. ");
                number = Console.ReadLine();
            } while (!double.TryParse(number, out anumber));

            Console.WriteLine($"The {anumber} squared is {anumber * anumber}.");
        }

    }
    
}
