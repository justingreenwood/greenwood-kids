using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchExample
{
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

        public static WordSearch CreateNew(int width, int height, List<string> words)
        {
            words = words.OrderByDescending(word => word.Length).ToList();

            var ws = new WordSearch { 
                Width = width, 
                Height = height, 
                WordSearchLetters = new char[width, height] 
            };

            // add the words
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
                    hiddenWord.Direction = (WordDirection)_random.Next(3);

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
                        case WordDirection.DIAGONAL:
                            hiddenWord.X = _random.Next(ws.Width - word.Length);
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
                    Console.WriteLine($"{word} - {attempts} attempt(s)");
                    ws.AddWord(hiddenWord);
                }
            }

            // fill the rest with random letters
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
}