using System;
using System.Collections.Generic;

namespace Kdramasareaweful
{
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
                case WordDirection.DIAGONAL:
                    return (x >= X && x < X + Word.Length) && (y >= Y && y < Y + Word.Length) && (x - X == y - Y);
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
                    case WordDirection.DIAGONAL: x++; y++; break;
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
                    case WordDirection.DIAGONAL: x++; y++; break;
                }
            }
        }
    }
}