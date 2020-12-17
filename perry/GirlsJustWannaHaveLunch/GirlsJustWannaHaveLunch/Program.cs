using System;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GirlsJustWannaHaveLunch
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        greg:
            Console.WriteLine("Welcome to the Dirt Castle, young knight.");
            Console.WriteLine("What do you say: (H)ello, (I) kill you, or (B)ye");
            string grape = Console.ReadLine();
            if (grape == "H")
                Console.WriteLine("You may enter.");
            else if (grape == "I")
                Console.WriteLine("Not before I kill you. YOU WERE STABBED!");
            else if (grape == "B")
                Console.WriteLine("What? Leave now? Ok, bye.");
            else
            {
                Console.WriteLine("I don't know what you mean.");
                goto greg;
            }
            int vampire = 10;
            int zombie = 10;
            string skeleton = "LEGOS";
            Console.CursorLeft = vampire;
            Console.CursorTop = zombie;
            Console.Write(skeleton);
            int i = 0;
            while (true)
            {
                Console.CursorLeft = vampire;
                Console.CursorTop = zombie;
                Thread.Sleep(500);

                if (skeleton == "LEGOS   ")
                {
                    skeleton = "ARE     ";
                    Console.Write(skeleton);
                }
                else if (skeleton == "ARE     ")
                {
                    skeleton = "AMAZING!";
                    Console.Write(skeleton);
                }
                else
                {
                    skeleton = "LEGOS   ";
                    i++;
                    Console.Write(skeleton);
                    if (i == 10)
                        break;

                }


            }

            Console.CursorLeft = 1;
            Console.CursorTop = 5;
            Console.WriteLine("Type Y, R, Or B ");
            var abcde = Console.ReadKey();
            if (abcde.Key == ConsoleKey.Y)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Clear();
            }
            else if (abcde.Key == ConsoleKey.R)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
            }
            else if (abcde.Key == ConsoleKey.B)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
            }
            else
                goto lkj;
            decimal butt = 0.5m;
            float poop = 1 / 4;
            int pee = 5;
            Console.WriteLine("Type a number 1-5");
            var canon = Console.ReadLine();
            switch (canon)
            {
                case "1":
                    Console.WriteLine(poop);
                    break;
                case "2":
                    Console.WriteLine(pee * poop);
                    break;
                case "3":
                    Console.WriteLine(pee * butt);
                    break;
                case "4":
                    Console.WriteLine(butt);
                    break;
                case "5":
                    Console.WriteLine(pee);
                    break;
                default:
                    Console.WriteLine("0.125");
                    break;

            }
            Console.WriteLine("Which do you prefer (c)oke or (p)epsi?");
            var soda = Console.ReadLine();
            if (soda == ("c"))
                Console.WriteLine("You prefer Coke like the majority of people.");
            else if (soda == "p")
                Console.WriteLine("You prefer Pepsi like the minority of people.");
            else
                Console.WriteLine("You don't have a preference.");
            Thread.Sleep(1000);

            var aaa = ConsoleColor.Cyan;
            while (true)
            {

                Thread.Sleep(300);
                if (aaa == ConsoleColor.Cyan)
                {
                    aaa = ConsoleColor.White;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Girls");
                }
                else if (aaa == ConsoleColor.White)
                {
                    aaa = ConsoleColor.Yellow;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Just");
                }
                else if (aaa == ConsoleColor.Yellow)
                {
                    aaa = ConsoleColor.Green;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Wanna");
                }
                else if (aaa == ConsoleColor.Green)
                {
                    aaa = ConsoleColor.Blue;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Have");
                }
                else if (aaa == ConsoleColor.Blue)
                {
                    aaa = ConsoleColor.Magenta;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Lunch");
                }
                else if (aaa == ConsoleColor.Magenta)
                {
                    aaa = ConsoleColor.Red;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("By");


                }
                else if (aaa == ConsoleColor.Red)
                {
                    aaa = ConsoleColor.Gray;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Wierd Al");
                }
                else if (aaa == ConsoleColor.Gray)
                {
                    aaa = ConsoleColor.Cyan;
                    Console.BackgroundColor = aaa;
                    Console.Clear();
                    Console.CursorLeft = 50;
                    Console.CursorTop = 13;
                    Console.WriteLine("Yankovic");
                }

            }
            lkj:
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(4 - 1 + 3 * 9 / 45);
            Console.WriteLine(Math.Round(Math.PI * (5.2 * 5.2), 2));
            Console.WriteLine(Math.Cos(19) - Math.Sin(43) + Math.Tan(54));
            Console.WriteLine(Math.Sqrt(144));
            Double number = 9, number1 = 13;
            Double answer = number * number1;
            Console.WriteLine($"number * number1 = {answer}");
            Double number2 = 1.4, number3 = 5.34;
            Double answer1 = number2 + answer / number3;
            Console.WriteLine($"number2 + answer / number3 = {answer1}");
            Console.WriteLine("Write something funny.");
            var thing = Console.ReadLine();
            if (thing == "something funny")
                Console.WriteLine("You win you get 100000000000000000000 dolors.");
            else
            {
                Double Numba = 1;
                while (true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(Numba);
                    Numba = Numba + Numba;
                    var numbs = Numba;
                    if (numbs == 2048)
                        break;
                }



            }
        }   
    }
}
