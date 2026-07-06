using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGame
{
    

    internal class Program
    {
        static string[] image = File.ReadAllLines(@"E:\github-projects\greenwood-kids\perry\ConsoleGame\ConsoleGame\TextFile1.txt");
        public static string playerName;
        static void Main(string[] args)
        {
            
            CPUSpeak("Unknown", "Welcome!");
            Console.WriteLine("What is your name?");
            Console.ForegroundColor = ConsoleColor.White;
            playerName = Respond();
            CPUSpeak("Unknown", $"Nice to meet you {playerName}.");
            PlayerSpeak("What should I do?");
            bool apple = true;
            while (apple)
            {
                switch (GiveCommand())
                {
                    case "look":
                        Look();
                        break;
                    case "look at inventory":
                        LookInventory();
                        break;
                    case "look at self":
                        LookAtSelf();
                        break;
                    case "talk to cashier":
                        TalkToEmployee();
                        break;
                    case "talk to employee":
                        TalkToEmployee();
                        break;
                    case "use knife on cashier":
                        Console.WriteLine("You do not want to do that.");
                        break;
                    case "use knife on employee":
                        Console.WriteLine("You do not want to do that.");
                        break;
                    case "use knife on self":
                        apple = false;
                        break;
                    default:
                        Console.WriteLine("I do not know how to do that.");
                        break;

                }
                Console.WriteLine();

            }
            Console.WriteLine("You Died!");
            Console.Beep(440, 750);
            Console.Beep(261, 750);
            Console.Beep(220, 1500);
            Console.ReadKey();

        }

        private static void Look()
        {
            Console.WriteLine("You see an employee at the cash register.");
        }
        private static void LookInventory()
        {
            Console.WriteLine("You have a knife.");
        }
        private static string GiveCommand()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine().ToLower();
        }
        private static string Respond()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        private static void TalkToEmployee()
        {
            Console.WriteLine("What would you like?");
            PlayerSpeak("What do you have?");
            while (true)
            {
                CPUSpeak("Cashier","We have (s)andwiches, (s)moothies, (s)oda, (s)ushi, (s)oup, and (s)chlop.");
                var food = Console.ReadKey();
                Console.WriteLine();
                if (food.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Great! Just a moment.");
                    break;
                }
                Console.WriteLine("That was not an option.");
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");

            }
            Thread.Sleep(1000);
            Console.WriteLine();
            CPUSpeak("Cashier","Here is your schlop.");
        }

        private static void PlayerSpeak(string words)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(playerName + " - ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(words);
        }
        private static void CPUSpeak(string name, string words)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(name + " - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(words);
        }
        private static void LookAtSelf()
        {            
            int n = 0;
            for (int i = 0; i < 7; i++)
            {

                for (int j = 0; j < image.Length / 7; j++)
                {
                    Console.Write(image.GetValue(n));
                    n++;
                }
                Console.WriteLine(" ");
            }
        }
    }



}
