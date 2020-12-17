using System;
using System.Collections.Generic;
using System.Linq;

namespace Kdramasareaweful
{
    class Program
    {
        static void Main(string[] args)
        {
            var showCheats = false;
            Console.Write("Show cheat colors? (Y/N)");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                {
                    showCheats = true;
                    break;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    break;
                }
                else
                {
                    Console.Beep();
                }
            } while (true);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            var listToAddItemsTo = new List<string>{
                //"Justin", "kelly", "Whitney", "spencer", "andromeda", "aurora", "perry", "greenwood",
                //"josephine", "abraham", "eugene", "renee", "bob", "foster", "elizabeth"
            };
            //listToAddItemsTo.Add("Mary");
            int ccc = 0;

            bool banana = true;

            while (true)
            {
            castle:
                Console.WriteLine("Type in a word less than 21 letters long.");
                string apple = null;
                var pear = Console.ReadLine().Trim().ToUpper();
                do
                {
                    apple = "";
                    foreach (char c in pear)
                    {
                        if (char.IsLetter(c)) apple += c;
                    }

                    if (apple.Length > 20 || apple.Length < 3 || listToAddItemsTo.Contains(apple))
                    {
                        Console.Beep();
                        goto castle;
                    }
                    else
                        break;
                } while (true);

                

                listToAddItemsTo.Add(apple);
                ccc++;
                if (ccc > 20)
                    break;
                Console.WriteLine("Do you want to add another word? (Y/N)");
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        banana = false;
                        break;
                    }
                    else
                        Console.Beep();

                } while (true);
                if(banana == false)
                    break;
            }
            Console.Clear();

            //var listToAddItemsTo = new List<string>{
            //    "Justin", "kelly", "Whitney", "spencer", "andromeda", "aurora", "perry", "greenwood",
            //    "josephine", "abraham", "eugene", "renee", "bob", "foster", "elizabeth"
            //};
            //listToAddItemsTo.Add("Mary");

            WordSearch ws = null;

            try
            {
                ws = WordSearch.CreateNew(20, 20, listToAddItemsTo);
            } 
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return;
            }

            for (var y = 0; y < ws.WordSearchLetters.GetLength(1); y++)
            {
                for (var x = 0; x < ws.WordSearchLetters.GetLength(0); x++)
                {
                    if (showCheats && ws.HasHiddenWord(x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write($"{ws.WordSearchLetters[x, y]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}