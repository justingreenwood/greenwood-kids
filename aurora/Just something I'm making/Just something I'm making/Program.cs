using System;

namespace Just_something_I_m_making
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
            Console.Clear();

            var listToAddItemsTo = new List<string>{
                "Justin", "kelly", "Whitney", "spencer", "andromeda", "aurora", "perry", "greenwood",
                "josephine", "abraham", "eugene", "renee", "bob", "foster", "elizabeth"
            };
            listToAddItemsTo.Add("Mary");

            WordSearch ws = null;

            try
            {
                ws = WordSearch.CreateNew(16, 16, listToAddItemsTo);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($"{ws.WordSearchLetters[x, y]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
