using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace AuroraIsBackIntheGame
{
    class Program
    {
        private static void Main(string[] args)
        {
            var showCheats = false;
            Console.Write("Show cheats? (Y/N)");
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
            var wordList = new Dictionary<string, string> {
                {"star", "Twinkle, twinkle little ____."},
                {"summer", "A warm season."},
                {"mother", " Is the most important part of your early existence."},
                {"rapunzel", "Was locked up in a tower."},
                {"green", "Leaves, celery, and grass are _____."},
                {"mammal", "Warm-blooded animals that breathe air and have fur."},
                {"taco", "Meat, cheese, and lettuce wrapped in a tortilla."},
                {"jasmine", "A bratty princess who is known for riding on a flying carpet."},
                {"rindercella", "A special version of Cinderella that messes with words."},
                {"pineapple", "There's one in every episode of Psych."},
                {"bacon", "Pi/Pa favorite food."},
                {"unicorn", "An acception to the normal a/an rules."},
                {"parents", "The people who raise you."},
                {"bread", "A fluffy loaf of _____ is a blessing to all."},
                {"magic", "The one thing that is in every fantasy story."},
                {"early", " Something that means 3 am to Aurora, 6 am to Andromeda, and 5:30 am to Perry."},
            };

            CrossWord cw = null;
            for (int tryIdx = 0; tryIdx < 100; tryIdx++)
            {
                cw = CrossWord.CreateNew(25, 25, wordList);
                if (cw != null) break;
            }

            if (cw == null)
            {
                Console.WriteLine("No luck making the crossword!");
            }
            else
            {
                for (var y = 0; y < cw.WordSearchLetters.GetLength(1); y++)
                {
                    for (var x = 0; x < cw.WordSearchLetters.GetLength(0); x++)
                    {
                        var hasWord = cw.HasWord(x, y);
                        if (hasWord)
                        {
                            var word = cw.GetWordIfFirstIndex(x, y);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            if (showCheats)
                                Console.Write($"{cw.WordSearchLetters[x, y]} ");
                            else
                            {
                                if (word != null)
                                {
                                    Console.ForegroundColor = (word.Direction == WordDirection.VERTICAL) ? ConsoleColor.DarkBlue : ConsoleColor.Cyan;
                                    Console.Write(word.Number.ToString().PadRight(2));
                                }
                                else
                                {
                                    Console.Write($"  ");
                                }
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write($"  ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write($"");
                        }
                    }
                    Console.WriteLine();
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("------------Down------------");
                foreach (var word in cw.Words.Where(x => x.Direction == WordDirection.VERTICAL).OrderBy(x => x.Number))
                {
                    Console.WriteLine($"{word.Number} - {word.Clue}");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-----------Across-----------");
                foreach (var word in cw.Words.Where(x => x.Direction == WordDirection.HORIZONTAL).OrderBy(x => x.Number))
                {
                    Console.WriteLine($"{word.Number} - {word.Clue}");
                }
            }
            Console.ReadKey();
        }
    }

    public class CrossWord
    {
        private static Random _random = new Random();

        public List<CrossWordEntry> Words = new List<CrossWordEntry>();
        public int Width = 20;
        public int Height = 20;

        public char[,] WordSearchLetters;

        public void AddWord(CrossWordEntry word)
        {
            word.AddToCrossWord(this);
            this.Words.Add(word);
        }

        public bool HasWord(int x, int y)
        {
            foreach (var word in Words)
            {
                if (word.ExistsAt(x, y)) return true;
            }
            return false;
        }

        public CrossWordEntry GetWordIfFirstIndex(int x, int y)
        {
            foreach (var word in Words)
            {
                if (word.X == x && word.Y == y) return word;
            }
            return null;
        }

        public static CrossWord CreateNew(int width, int height, Dictionary<string, string> entries)
        {
            var cw = new CrossWord { Width = width, Height = height, WordSearchLetters = new char[width, height] };


            var maxAttempts = cw.Width * cw.Height * 10;
            int idx = 0, lastSkippedCount = 0;
            var skippedWords = new List<CrossWordEntry>();
            var words = entries.Keys.Select(word => new CrossWordEntry
            {
                Word = word.ToUpper(),
                Clue = entries[word]
            }).ToList();

            do
            {
                while (skippedWords.Count > 0)
                {
                    var randIdx = _random.Next(skippedWords.Count);
                    words.Add(skippedWords[randIdx]);
                    skippedWords.RemoveAt(randIdx);
                }

                foreach (var entry in words)
                {
                    int attempts = 0;
                    do
                    {
                        entry.Direction = (WordDirection)_random.Next(3);

                        switch (entry.Direction)
                        {
                            case WordDirection.HORIZONTAL:
                                entry.X = _random.Next(cw.Width - entry.Word.Length);
                                entry.Y = _random.Next(cw.Height);
                                break;

                            case WordDirection.VERTICAL:
                                entry.X = _random.Next(cw.Width);
                                entry.Y = _random.Next(cw.Height - entry.Word.Length);
                                break;
                        }
                        attempts++;
                    } while (!entry.FitsInCrossWord(cw, (idx > 0)) && attempts < maxAttempts);

                    if (attempts >= maxAttempts)
                    {
                        skippedWords.Add(entry);
                        continue;
                    }
                    else
                    {
                        cw.AddWord(entry);
                        idx++;
                    }
                }
                words.Clear();
                if (skippedWords.Count > 0 && lastSkippedCount == skippedWords.Count) return null;
                else lastSkippedCount = skippedWords.Count;
            } while (skippedWords.Count > 0);

            cw.AssignNumbers();
            return cw;
        }
        protected void AssignNumbers()
        {
            int i = 1;
            foreach (var word in Words.Where(x => x.Direction == WordDirection.HORIZONTAL).OrderBy(x => x.Y).ThenBy(x => x.X))
                word.Number = i++;
            i = 1;
            foreach (var word in Words.Where(x => x.Direction == WordDirection.VERTICAL).OrderBy(x => x.X).ThenBy(x => x.Y))
                word.Number = i++;
        }
    }
    public enum WordDirection
    {
        VERTICAL = 0,
        HORIZONTAL = 1
    }
    public class CrossWordEntry
    {
        private const char NULL = '\0';
        public WordDirection Direction;
        public int Number;
        public int X;
        public int Y;
        public string Word;
        public string Clue;
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
        public bool FitsInCrossWord(CrossWord cw, bool mustCross = true)
        {
            bool crosses = false;
            int x = X, y = Y;
            switch (Direction)
            {
                case WordDirection.HORIZONTAL:
                    if (x > 0 && cw.WordSearchLetters[x - 1, y] != NULL) return false;
                    else if (x + Word.Length < cw.Width - 1 && cw.WordSearchLetters[x + Word.Length + 1, y] != NULL) return false;
                    break;

                case WordDirection.VERTICAL:
                    if (y > 0 && cw.WordSearchLetters[x, y - 1] != NULL) return false;
                    else if (y + Word.Length < cw.Height - 1 && cw.WordSearchLetters[x, y + Word.Length + 1] != NULL) return false;
                    break;
            }
            for (int i = 0; i < Word.Length; i++)
            {
                var wordSearchLetter = cw.WordSearchLetters[x, y];
                var isLetterMatch = wordSearchLetter == Char.ToUpper(Word[i]);
                if (isLetterMatch) crosses = true;
                if (wordSearchLetter != NULL && !isLetterMatch)
                {
                    return false;
                }
                if (!isLetterMatch)
                {
                    switch (Direction)
                    {
                        case WordDirection.HORIZONTAL:
                            if ((y < cw.Height - 1) && cw.WordSearchLetters[x, y + 1] != NULL) return false;
                            else if ((y > 0) && cw.WordSearchLetters[x, y - 1] != NULL) return false;
                            break;

                        case WordDirection.VERTICAL:
                            if ((x < cw.Width - 1) && cw.WordSearchLetters[x + 1, y] != NULL) return false;
                            else if ((x > 0) && cw.WordSearchLetters[x - 1, y] != NULL) return false;
                            break;
                    }
                }
                switch (Direction)
                {
                    case WordDirection.HORIZONTAL: x++; break;
                    case WordDirection.VERTICAL: y++; break;
                }
            }
            return mustCross ? crosses : true;
        }
        public void AddToCrossWord(CrossWord ws)
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




