using System;

namespace MadLibPerrys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to serious stories.");
            beginning:
            Console.WriteLine("Write a noun.");
            string  time = Console.ReadLine();

            Console.WriteLine("Write a verb.");
            string  was = Console.ReadLine();

            Console.WriteLine("Write an adjective");
            string weird = Console.ReadLine();

            //Console.WriteLine("Write a verb ending in ed.");
            //string  named = Console.ReadLine();

            Console.WriteLine("Write a name.");
            string  flabby = Console.ReadLine();

            Console.WriteLine("Write a number.");
            string  firstnumber = Console.ReadLine();

            Console.WriteLine("Write a color");
            string white = Console.ReadLine();

            Console.WriteLine("Write a plural noun.");
            string  cats = Console.ReadLine();

            Console.WriteLine("Write a noun.");
            string  sister = Console.ReadLine();

            Console.WriteLine("Write a name.");
            string candy = Console.ReadLine();

            Console.WriteLine("Write a verb ending in ing.");
            string  torturing = Console.ReadLine();

            Console.WriteLine("Write an adjective.");
            string innocent = Console.ReadLine();

            Console.WriteLine("Write a plural noun.");
            string animals = Console.ReadLine();

            Console.WriteLine("Write an adjective.");
            string amazing = Console.ReadLine();

            //Console.WriteLine("Write a noun.");
            //string secondsister = Console.ReadLine();

            //Console.WriteLine("Write a verb.");
            //string mows = Console.ReadLine();

            Console.WriteLine("Write a conjunction.");
            string and = Console.ReadLine();

            Console.WriteLine("Write a verb.");
            string rakes = Console.ReadLine();

            Console.WriteLine("Write a number");
            string secondnumber = Console.ReadLine();

            Console.WriteLine("Write a pronoun.");
            string he = Console.ReadLine();

            Console.WriteLine("Write a verb ending in ing.");
            string hitting = Console.ReadLine();

            Console.WriteLine("Write a verb ending in ed.");
            string grounded = Console.ReadLine();

            Console.WriteLine("Write a noun.");
            string end = Console.ReadLine();

            Console.WriteLine($"  Once upon a {time} there {was} a {weird} boy named {flabby}.");
            Console.WriteLine($"He owned {firstnumber} {white} {cats} and had a {sister} named {candy}.");
            Console.WriteLine($"{flabby} likes {torturing} {innocent} {animals}, but his {amazing} {candy} hates when he does it.");
            Console.WriteLine($"{candy} mows {and} {rakes} lawns for {secondnumber} dollars.");
            Console.WriteLine($"{he} stopped {hitting} animals after he was {grounded} for it.");
            Console.WriteLine($"                The {end}");

            Console.ReadKey();

            thing:

            Console.WriteLine("Do you want to play again? (y or n)");
            var answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Y)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Good Choice.");
                goto beginning;
            }
            else if (answer.Key == ConsoleKey.N)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Ok, Bye.");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("That isn't y or n.");
                goto thing;
            }
        }
    }
}
