using System;

namespace easy_stuff_for_evy
{
    using System;
    using System.Collections.Generic;
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

            var wordList = new string[] {
               "and","for","off","saw","the","you","all","can","two","was","will","any" 
            };

            var wordList2 = new string[] {
               "are","come","four","have","her","look","one","over","said","see","she","that"
            };

            var wordList3 = new string[] {
              "them","this","three","want","would","where","whose","put" 
            };
            Console.Write("which option(w1,e2,t3)");
            ConsoleKeyInfo num;
            do
            {
                num = Console.ReadKey(true);
                if (num.Key == ConsoleKey.W)
                {
                    Console.Clear();
                    var ws = WordSearch.CreateNew(10, 10, wordList);
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
                    break;
                }
                else if (num.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    var ws = WordSearch.CreateNew(10, 10, wordList2);
                    for (var y = 0; y < ws.WordSearchLetters.GetLength(1); y++)
                    {
                        for (var x = 0; x < ws.WordSearchLetters.GetLength(0); x++)
                        {
                            if (showCheats && ws.HasHiddenWord(x, y))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
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
                    break;
                }
                else if (num.Key == ConsoleKey.T)
                {
                    Console.Clear();
                    var ws = WordSearch.CreateNew(10, 10, wordList3);

                    for (var y = 0; y < ws.WordSearchLetters.GetLength(1); y++)
                    {
                        for (var x = 0; x < ws.WordSearchLetters.GetLength(0); x++)
                        {
                            if (showCheats && ws.HasHiddenWord(x, y))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
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
                    break;
                }
                else
                {
                    Console.Beep();
                }
            } while (true);
        }
    }

    public class WordSearch
    {
        private static Random _random = new Random();

        public List<HiddenWord> Words = new List<HiddenWord>();
        public int Width = 15;
        public int Height = 15;

        public char[,] WordSearchLetters;

        public void AddWord(HiddenWord word)
        {
            word.AddToWordSearch(this);
            this.Words.Add(word);
        }

        public bool HasHiddenWord(int x, int y)
        {
            foreach (var word in Words)
            {
                if (word.ExistsAt(x, y)) return true;
            }
            return false;
        }

        public static WordSearch CreateNew(int width, int height, string[] words)
        {
            var ws = new WordSearch { Width = width, Height = height, WordSearchLetters = new char[width, height] };

            var maxAttempts = ws.Width * ws.Height * 10;
            foreach (var word in words)
            {
                var hiddenWord = new HiddenWord
                {
                    Word = word.ToUpper()
                };

                int attempts = 0;
                do
                {
                    hiddenWord.Direction = (WordDirection)_random.Next(2);

                    switch (hiddenWord.Direction)
                    {
                        case WordDirection.HORIZONTAL:
                            hiddenWord.X = _random.Next(ws.Width - word.Length);
                            hiddenWord.Y = _random.Next(ws.Height);
                            break;
                        case WordDirection.VERTICAL:
                            hiddenWord.X = _random.Next(ws.Width);
                            hiddenWord.Y = _random.Next(ws.Height - word.Length);
                            break;
                    }
                    attempts++;

                } while (!hiddenWord.FitsInWordSearch(ws) && attempts < maxAttempts);

                if (attempts >= maxAttempts)
                {
                    throw new Exception("SORRY! This ain't going to work.");
                }
                else
                {
                    ws.AddWord(hiddenWord);
                }
            }

            
            for (var y = 0; y < ws.WordSearchLetters.GetLength(1); y++)
            {
                for (var x = 0; x < ws.WordSearchLetters.GetLength(0); x++)
                {
                    if (ws.WordSearchLetters[x, y] == '\0')
                    {
                        ws.WordSearchLetters[x, y] = (char)('A' + _random.Next(0, 26));
                    }
                }
            }

            return ws;
        }
    }

    public enum WordDirection
    {
        VERTICAL = 0,
        HORIZONTAL = 1,
    }

    public class HiddenWord
    {
        public WordDirection Direction;
        public int X;
        public int Y;
        public string Word;

        public bool ExistsAt(int x, int y)
        {
            switch (Direction)
            {
                case WordDirection.HORIZONTAL:
                    return (x >= X && x < X + Word.Length) && (y == Y);
                case WordDirection.VERTICAL:
                    return (x == X) && (y >= Y && y < Y + Word.Length); 
            }
            return false;
        }

        public bool FitsInWordSearch(WordSearch ws)
        {
            int x = X, y = Y;
            for (int i = 0; i < Word.Length; i++)
            {
                var wordSearchLetter = ws.WordSearchLetters[x, y];
                if (wordSearchLetter != '\0' && wordSearchLetter != Char.ToUpper(Word[i]))
                {
                    return false;
                }
                switch (Direction)
                {
                    case WordDirection.HORIZONTAL: x++; break;
                    case WordDirection.VERTICAL: y++; break;
                }
            }
            return true;
        }
        public void AddToWordSearch(WordSearch ws)
        {
            int x = X, y = Y;
            for (int i = 0; i < Word.Length; i++)
            {
                ws.WordSearchLetters[x, y] = Word[i];
                switch (Direction)
                {
                    case WordDirection.HORIZONTAL: x++; break;
                    case WordDirection.VERTICAL: y++; break;
                }
            }
        }
    }
}