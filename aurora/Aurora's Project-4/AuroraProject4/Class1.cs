using System;
using System.Collections.Generic;
using System.Text;

namespace AuroraProject4
{
    public class UghMath
    {
        public static void Addition()
        {
            string Potato;
            int Potatoes;
            do
            {
                Console.WriteLine(" Young human, give me a number!");
                Potato = Console.ReadLine();

            } while (!int.TryParse(Potato, out Potatoes));

            string Douglet;
            int Dougie;
            do
            {
                Console.WriteLine(" Young human, give me another number!");
                Douglet = Console.ReadLine();

            } while (!int.TryParse(Douglet, out Dougie));

            Console.WriteLine($" Your stupid poopface thingamabobber is {Potatoes + Dougie}! Do you understand, dumbnut?");
        }
        public static void Subtraction()
        {
            string Potato;
            int Potatoes;
            do
            {
                Console.WriteLine(" Young human, give me a number!");
                Potato = Console.ReadLine();

            } while (!int.TryParse(Potato, out Potatoes));

            string Douglet;
            int Dougie;
            do
            {
                Console.WriteLine(" Young human, give me another number!");
                Douglet = Console.ReadLine();

            } while (!int.TryParse(Douglet, out Dougie));

            Console.WriteLine($" Your guilty pleasure equals {Potatoes - Dougie}! Now, never subtract me from this again!");
        }

        public static void Hell()
        {
            string Potato;
            int Potatoes;
            do
            {
                Console.WriteLine(" Demon child, give me a number!");
                Potato = Console.ReadLine();

            } while (!int.TryParse(Potato, out Potatoes));

            string Douglet;
            int Dougie;
            do
            {
                Console.WriteLine(" Give me another number, you son of a witch!");
                Douglet = Console.ReadLine();

            } while (!int.TryParse(Douglet, out Dougie));

            Console.WriteLine($" You look too dumb to understand, hell spawn, but the answer is {Potatoes / Dougie}!");
        }
        public static void Multiplication()
        {
            string Potato;
            int Potatoes;
            do
            {
                Console.WriteLine(" Young human, give me a number!");
                Potato = Console.ReadLine();

            } while (!int.TryParse(Potato, out Potatoes));

            string Douglet;
            int Dougie;
            do
            {
                Console.WriteLine(" Young human, give me another number!");
                Douglet = Console.ReadLine();

            } while (!int.TryParse(Douglet, out Dougie));

            Console.WriteLine($" As much as I hate to say it, your stupid poopface thingamabobber is {Potatoes * Dougie}! Do you understand how deep my disdain is?");
        }

    }
}
